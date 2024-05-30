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
    private boolean isFindId;

    public Controller() {
        this.iView = new FrameClient(this);
        this.accountDao = new AccountDao();
        this.isFindId = false;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        System.out.println(e.getActionCommand());
        switch (e.getActionCommand()) {
            case Texts.GO_BACK -> iView.showScreen(Enums.ScreenType.LogIn);
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
        }
    }

    private void processLogIn() {
        HashMap<Enums.TextType, String> inputTextMap = iView.getText(Enums.ScreenType.LogIn);
        String inputId = inputTextMap.get(Enums.TextType.Id);
        String password = inputTextMap.get(Enums.TextType.Password);
        HashMap<Enums.TextType, String> userMap = accountDao.findUser(inputId);

        if (userMap.isEmpty() || !password.equals(userMap.get(Enums.TextType.Password))) {
            iView.showDialog(false, Texts.LOGIN_FAIL);
            return;
        }

        iView.showDialog(true, Texts.LOGIN_COMPLETE);
        iView.showScreen(Enums.ScreenType.Home);
    }
}
