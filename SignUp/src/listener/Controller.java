package listener;

import constant.APITexts;
import constant.DialogTexts;
import constant.Enums;
import constant.Texts;
import model.AccountDao;
import model.AddressDao;
import model.IAccount;
import model.IAddress;
import view.FrameClient;
import view.IView;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.util.HashMap;
import java.util.List;

public class Controller implements ActionListener {

    private final IView iView;
    private final IAccount iAccount;
    private final IAddress iAddress;
    private boolean isFoundId;
    private boolean isCheckedAddress;
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

            //===== LogIn Screen Buttons =====//
            case Texts.LOGIN -> processLogIn();
            case Texts.SIGNUP -> iView.showScreen(Enums.ScreenType.SignUp);
            case Texts.FIND_ID -> {
                isFoundId = true;
                iView.showScreen(Enums.ScreenType.Find);
            }
            case Texts.FIND_PASSWORD -> {
                isFoundId = false;
                iView.showScreen(Enums.ScreenType.Find);
            }

            //===== Home Screen Buttons =====//
            case Texts.ACCOUNT_MODIFY -> {
                iView.showScreen(Enums.ScreenType.Modify);
                iView.setTextField(Enums.ScreenType.Modify, loggedInAccount);
            }
            case Texts.ACCOUNT_DELETE -> processDelete();

            //===== SignUp Screen Buttons =====//
            case Texts.DUPLICATION_CHECK -> checkIdDuplication();
            case Texts.ADDRESS_CHECK -> checkAddress();
            case Texts.SIGNUP_CHECK -> processSignUp();
            case Texts.MODIFIED_CHECK -> processModified();
            case Texts.FIND_ADDRESS -> processFindAddress();

            //===== AccountFinder Screen Buttons =====//
            case Texts.GET_CODE -> {

            }
            case Texts.OK -> {

            }
        }
    }

    private void processLogOut() {
        this.isFoundId = false;
        this.isCheckedDuplication = false;
        this.isCheckedAddress = false;
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

    private void checkAddress() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.Modify);

        if (loggedInAccount.isEmpty()) { // signup screen 일 때
            inputTextMap = iView.getText(Enums.ScreenType.SignUp);
        }

        String foundAddress = iAddress.searchAddress(inputTextMap.get(Enums.TextType.Address));
        if (foundAddress == null || foundAddress.isEmpty()) {
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.ADDRESS));
            return;
        }

        HashMap<Enums.TextType, String> map = new HashMap<>();
        map.put(Enums.TextType.Address, foundAddress);
        isCheckedAddress = true;

        if (loggedInAccount.isEmpty()) { // signup screen 일 때
            iView.setTextField(Enums.ScreenType.SignUp, map);
        }
        iView.setTextField(Enums.ScreenType.Modify, map);
        iView.showDialog(true, DialogTexts.ADDRESS_COMPLETE);
    }

    private void processSignUp() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.SignUp);

        if (!isValidSignUp(inputTextMap)) {
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

        if (!inputTextMap.containsKey(Enums.TextType.Id) || inputTextMap.get(Enums.TextType.Id).length() != 8) { // 올바른 id 입력을 했는지
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.ID));
            return;
        }

        String inputId = inputTextMap.get(Enums.TextType.Id);

        if (!isValidDigit(false, inputId.toCharArray())) {  // 올바른 입력이 아니라면
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.ID));
        }

        for (String id : idList) {   // 중복 체크
            if (inputId.equals(id)) {
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

    private void processFindAddress() {
        String urlLink = APITexts.ADDRESS_URL;
        try {
            Desktop.getDesktop().browse(new URL(urlLink).toURI());
        } catch (IOException | URISyntaxException e) {
            e.printStackTrace();
        }
    }

    private boolean isValidSignUp(HashMap<Enums.TextType, String> inputTextMap) {
        if (!isCheckedDuplication) { // 중복 확인 버튼을 누르지 않았을 때
            iView.showDialog(false, DialogTexts.REQUEST_DUPLICATION_BUTTON);
            return false;
        }

        for (String inputText : inputTextMap.values()) {
            if (inputText.isEmpty()) {  // 입력하지 않은 TextField 존재할 때
                iView.showDialog(false, DialogTexts.REQUEST_INPUT_ALL);
                return false;
            }
        }

        if (isValidDigit(false, inputTextMap.get(Enums.TextType.Name).toCharArray()) ||
                inputTextMap.get(Enums.TextType.Name).length() < 2) { // 올바른 이름 입력이 아닐 때
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.NAME));
            return false;
        }

        if (!inputTextMap.get(Enums.TextType.Password).equals   // 비밀번호와 비밀번호 확인이 다를 때
                (inputTextMap.get(Enums.TextType.PasswordCheck))) {
            iView.showDialog(false, DialogTexts.WRONG_PASSWORD);
            return false;
        }

        if (!isCheckedAddress) {    // 주소가 올바르지 않을 때
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.ADDRESS));
            return false;
        }

        if (isValidDigit(true, inputTextMap.get(Enums.TextType.Password).toCharArray()) ||
                inputTextMap.get(Enums.TextType.PasswordCheck).length() != 4) { // 올바른 비밀번호 입력이 아닐 때
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.PASSWORD));
            return false;
        }

        if (isValidDigit(true, inputTextMap.get(Enums.TextType.BirthDay).toCharArray()) ||
                inputTextMap.get(Enums.TextType.BirthDay).length() != 8) { // 올바른 생일 입력이 아닐 때
            iView.showDialog(false, String.format(DialogTexts.REQUEST_INPUT, Texts.BIRTHDAY));
            return false;
        }

        return true;
    }

    private boolean isValidDigit(boolean isDigit, char[] inputList) {
        for (char c : inputList) {
            if (Character.isDigit(c) == isDigit) {
                return false;
            }
        }
        return true;
    }
}
