package listener;

import constant.Enums;
import constant.Texts;
import model.AccountDao;
import view.FrameClient;
import view.IView;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class Controller implements ActionListener {

    private IView iView;
    private AccountDao accountDao;

    public Controller() {
        this.iView = new FrameClient(this);
        this.accountDao = new AccountDao();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        switch (e.getActionCommand()) {
            case Texts.LOGIN -> processLogIn();
            case Texts.SIGNUP -> processSignUp();
            case Texts.FIND_ID -> processFindId();
            case Texts.FIND_PASSWORD -> processFindPassword();
        }
    }

    private void processLogIn() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.LogIn);
        String inputId = inputTextMap.get(Enums.TextType.Id);
        String password = inputTextMap.get(Enums.TextType.Password);
        HashMap<Enums.TextType, String> userMap = accountDao.findUser(inputId);

        if (userMap.isEmpty() || !password.equals(userMap.get(Enums.TextType.Password))) {
            System.out.println("Test");
            return;
        }

        iView.showScreen(Enums.ScreenType.Home);
    }

    private void processSignUp() {

    }

    private void processFindId() {

    }

    private void processFindPassword() {

    }

}
