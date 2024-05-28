package listener;

import constant.Enums;
import constant.Texts;
import view.FrameClient;
import view.IView;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashMap;

public class Controller implements ActionListener {

    IView iView;

    public Controller() {
        this.iView = new FrameClient(this);
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
        HashMap<Enums.TextType, String > map = iView.getText(Enums.ScreenType.LogIn);
        System.out.println(map.get(Enums.TextType.Id));
        System.out.println(map.get(Enums.TextType.Password));
    }

    private void processSignUp() {

    }

    private void processFindId() {

    }

    private void processFindPassword() {

    }
}
