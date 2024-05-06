package observer;

import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;

public class ButtonActionListener implements ActionListener {

    private String operator;
    private List<String> operands;

    public ButtonActionListener() {
        this.operator = "";
        this.operands = new ArrayList<>();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        boolean isKeypad = false;

        for(String item : Constants.BUTTON_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                isKeypad = true;
                if (item.chars().allMatch(Character::isDigit))
                    operands.add(item);
                else {
                    operator = item;
                    compute();
                }
            }
        }

        if (!isKeypad) {

        }
    }

    private void compute() {

    }
}
