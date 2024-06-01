package listener;

import constant.Enums;
import constant.Texts;
import model.AccountDao;
import view.FrameClient;
import view.IView;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;
import java.util.List;

public class Controller implements ActionListener {

    private IView iView;
    private AccountDao accountDao;
    private boolean isFindId;
    private boolean isCheckedDuplication;
    private String logInId;

    public Controller() {
        this.iView = new FrameClient(this);
        this.accountDao = new AccountDao();
        this.isFindId = false;
        this.isCheckedDuplication = false;
        this.logInId = "";
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        switch (e.getActionCommand()) {
            case Texts.GO_BACK, Texts.LOGOUT -> iView.showScreen(Enums.ScreenType.LogIn);

            //===== LogIn Screen 버튼들 =====//
            case Texts.LOGIN -> processLogIn();
            case Texts.SIGNUP -> iView.showScreen(Enums.ScreenType.SignUp);
            case Texts.FIND_ID -> {
                isFindId = true;
                iView.showScreen(Enums.ScreenType.Find);
            }
            case Texts.FIND_PASSWORD -> {
                isFindId = false;
                iView.showScreen(Enums.ScreenType.Find);
            }

            //===== Home Screen 버튼들 =====//
            case Texts.ACCOUNT_MODIFY -> iView.showScreen(Enums.ScreenType.Modified);
            case Texts.ACCOUNT_DELETE -> processDelete();

            //===== SignUp Screen 버튼들 =====//
            case Texts.DUPLICATION_CHECK -> checkIdDuplication();
            case Texts.FIND_ADDRESS -> {

            }
            case Texts.SIGNUP_CHECK -> processSignUp();
            case Texts.MODIFIED_CHECK -> {

            }

            //===== Find Screen 버튼들 =====//
            case Texts.GET_CODE -> {

            }
            case Texts.OK -> {

            }
        }
    }

    private void processLogIn() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.LogIn);
        String inputId = inputTextMap.get(Enums.TextType.Id);
        String inputPassword = inputTextMap.get(Enums.TextType.Password);
        HashMap<Enums.TextType, String> userMap = accountDao.findAccount(inputId);

        if (userMap.isEmpty() || !inputPassword.equals(userMap.get(Enums.TextType.Password))) {
            iView.showDialog(false, Texts.LOGIN_FAIL);
            return;
        }

        logInId = inputId;
        iView.showDialog(true, Texts.LOGIN_COMPLETE);
        iView.showScreen(Enums.ScreenType.Home);
    }

    private void processSignUp() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.SignUp);

        if (!isCheckedDuplication) { // 중복 확인 버튼을 누르지 않았을 때
            iView.showDialog(false, Texts.REQUEST_DUPLICATION);
            return;
        }

        for (String inputText : inputTextMap.values()) {
            if (inputText.isEmpty()) {  // 입력하지 않은 TextField 존재할 때
                iView.showDialog(false, Texts.REQUEST_INPUT);
                return;
            }
        }

        if (!inputTextMap.get(Enums.TextType.Password).equals   // 비밀번호와 비밀번호 확인이 다를 때
                (inputTextMap.get(Enums.TextType.PasswordCheck))) {
            iView.showDialog(false, Texts.WRONG_PASSWORD);
            return;
        }

        //===== SignUp complete =====//
        accountDao.insertAccount(inputTextMap);
        iView.showDialog(true, Texts.SIGNUP_COMPLETE);
        iView.showScreen(Enums.ScreenType.LogIn);
        isCheckedDuplication = false;
    }

    private void processDelete() {
        accountDao.deleteAccount(logInId);
        iView.showDialog(true, Texts.DELETE_COMPLETE);
        iView.showScreen(Enums.ScreenType.LogIn);
    }

    private void checkIdDuplication() {
        List<String> idList = accountDao.getIdList();
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.SignUp);

        if (!inputTextMap.containsKey(Enums.TextType.Id)) { // id 입력을 했는지
            iView.showDialog(false, Texts.REQUEST_INPUT_ID);
            return;
        }

        for (String id : idList) {   // 중복 체크
            if (inputTextMap.get(Enums.TextType.Id).equals(id)) {
                iView.showDialog(false, Texts.DUPLICATION);
                return;
            }
        }

        isCheckedDuplication = true;
        iView.showDialog(true, Texts.AVAILABLE_ID);
    }
}
