package Observer;

import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;

public class ButtonActionListener implements ActionListener {

    private List<Integer> operators;
    private List<String> operands;

    public ButtonActionListener() {
        this.operators = new ArrayList<>();
        this.operands = new ArrayList<>();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        boolean isKeypad = false;

        for(String item : Constants.BUTTON_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                isKeypad = true;
                if (item.chars().allMatch(Character::isDigit))
                    operators.add(Integer.parseInt(item));
                else
                    operands.add(item);
            }
        }

        if (!isKeypad) {

        }
    }
}
