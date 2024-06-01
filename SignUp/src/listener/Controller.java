package listener;

import constant.DialogTexts;
import constant.Enums;
import constant.Texts;
import model.AccountDao;
import model.AddressDao;
import model.IAccount;
import model.IAddress;
import view.FrameClient;
import view.IView;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;
import java.util.List;

public class Controller implements ActionListener {

    private final IView iView;
    private final IAccount iAccount;
    private final IAddress iAddress;
    private boolean isFindId;
    private boolean isCheckedDuplication;
    private HashMap<Enums.TextType, String> loggedInAccount;

    public Controller() {
        this.iView = new FrameClient(this);
        this.iAccount = new AccountDao();
        this.iAddress = new AddressDao();
        processLogOut();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        switch (e.getActionCommand()) {
            case Texts.GO_BACK, Texts.LOGOUT -> processLogOut();

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
            case Texts.ACCOUNT_MODIFY -> {
                iView.setTextField(Enums.ScreenType.Modify, loggedInAccount);
                iView.showScreen(Enums.ScreenType.Modify);
            }
            case Texts.ACCOUNT_DELETE -> processDelete();

            //===== SignUp Screen 버튼들 =====//
            case Texts.DUPLICATION_CHECK -> checkIdDuplication();
            case Texts.FIND_ADDRESS -> processFindAddress();
            case Texts.SIGNUP_CHECK -> processSignUp();
            case Texts.MODIFIED_CHECK -> processModified();

            //===== Find Screen 버튼들 =====//
            case Texts.GET_CODE -> {

            }
            case Texts.OK -> {

            }
        }
    }

    private void processLogOut() {
        this.isFindId = false;
        this.isCheckedDuplication = false;
        this.loggedInAccount = new HashMap<>();
        iView.showScreen(Enums.ScreenType.LogIn);
    }

    private void processLogIn() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.LogIn);
        String inputId = inputTextMap.get(Enums.TextType.Id);
        String inputPassword = inputTextMap.get(Enums.TextType.Password);
        loggedInAccount = iAccount.findAccount(inputId);

        if (loggedInAccount.isEmpty() || !inputPassword.equals(loggedInAccount.get(Enums.TextType.Password))) {
            iView.showDialog(false, DialogTexts.LOGIN_FAIL);
            return;
        }

        iView.showDialog(true, DialogTexts.LOGIN_COMPLETE);
        iView.showScreen(Enums.ScreenType.Home);
    }

    private void processFindAddress() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.Modify);

        if (loggedInAccount.isEmpty()) { // signup screen 일 때
            inputTextMap = iView.getText(Enums.ScreenType.SignUp);
        }

        if (inputTextMap.get(Enums.TextType.Address).isEmpty()) {
            iView.showDialog(false, DialogTexts.REQUEST_INPUT_ADDRESS);
            return;
        }

        String address = iAddress.searchAddress(inputTextMap.get(Enums.TextType.Address));

        if (address == null || address.isEmpty()) {
            iView.showDialog(false, DialogTexts.WRONG_ADDRESS);
            return;
        }

        HashMap <Enums.TextType, String> map = new HashMap<>();
        map.put(Enums.TextType.Address, address);

        if (loggedInAccount.isEmpty()) { // signup screen 일 때
            iView.setTextField(Enums.ScreenType.SignUp, map);
        }
        iView.setTextField(Enums.ScreenType.Modify, map);
    }

    private void processSignUp() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.SignUp);

        if (!isCheckedDuplication) { // 중복 확인 버튼을 누르지 않았을 때
            iView.showDialog(false, DialogTexts.REQUEST_DUPLICATION);
            return;
        }

        for (String inputText : inputTextMap.values()) {
            if (inputText.isEmpty()) {  // 입력하지 않은 TextField 존재할 때
                iView.showDialog(false, DialogTexts.REQUEST_INPUT);
                return;
            }
        }

        if (!inputTextMap.get(Enums.TextType.Password).equals   // 비밀번호와 비밀번호 확인이 다를 때
                (inputTextMap.get(Enums.TextType.PasswordCheck))) {
            iView.showDialog(false, DialogTexts.WRONG_PASSWORD);
            return;
        }

        //===== SignUp complete =====//
        iAccount.insertAccount(inputTextMap);
        isCheckedDuplication = false;
        iView.showDialog(true, DialogTexts.SIGNUP_COMPLETE);
        iView.showScreen(Enums.ScreenType.LogIn);
    }

    private void processDelete() {
        iAccount.deleteAccount(loggedInAccount.get(Enums.TextType.Id));
        iView.showDialog(true, DialogTexts.DELETE_COMPLETE);
        iView.showScreen(Enums.ScreenType.LogIn);
    }

    private void checkIdDuplication() {
        List<String> idList = iAccount.getIdList();
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.SignUp);

        if (!inputTextMap.containsKey(Enums.TextType.Id)) { // id 입력을 했는지
            iView.showDialog(false, DialogTexts.REQUEST_INPUT_ID);
            return;
        }

        for (String id : idList) {   // 중복 체크
            if (inputTextMap.get(Enums.TextType.Id).equals(id)) {
                iView.showDialog(false, DialogTexts.DUPLICATION);
                return;
            }
        }

        isCheckedDuplication = true;
        iView.showDialog(true, DialogTexts.AVAILABLE_ID);
    }

    private void processModified() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.Modify);
        String loggedInId = loggedInAccount.get(Enums.TextType.Id);
        String name = inputTextMap.get(Enums.TextType.Name);
        String password = inputTextMap.get(Enums.TextType.Password);
        String birthday = inputTextMap.get(Enums.TextType.BirthDay);
        String email = inputTextMap.get(Enums.TextType.Email);
        String phoneNumber = inputTextMap.get(Enums.TextType.PhoneNumber);
        String address = inputTextMap.get(Enums.TextType.Address);
        String detailedAddress = inputTextMap.get(Enums.TextType.DetailedAddress);

        if (!name.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.NAME, inputTextMap.get(Enums.TextType.Name));
        }
        if (!password.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.PASSWORD, inputTextMap.get(Enums.TextType.Password));
        }
        if (!birthday.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.BIRTHDAY, inputTextMap.get(Enums.TextType.BirthDay));
        }
        if (!email.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.EMAIL, inputTextMap.get(Enums.TextType.Email));
        }
        if (!phoneNumber.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.PHONE_NUMBER, inputTextMap.get(Enums.TextType.PhoneNumber));
        }
        if (!address.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.ADDRESS, inputTextMap.get(Enums.TextType.Address));
        }
        if (!detailedAddress.isEmpty()) {
            iAccount.modifyAccount(loggedInId, Texts.DETAILED_ADDRESS, inputTextMap.get(Enums.TextType.DetailedAddress));
        }

        iView.showDialog(true, DialogTexts.MODIFY_COMPLETE);
        iView.showScreen(Enums.ScreenType.Home);
    }
}
