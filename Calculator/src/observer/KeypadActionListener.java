package observer;

import model.CalculationRepository;
import utility.Constants;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class KeypadActionListener implements ActionListener {

    private CalculationRepository calculationRepository;

    public KeypadActionListener() {
        this.calculationRepository = new CalculationRepository();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        for(String item : Constants.BUTTON_STRINGS) {
            if (item.equals(e.getActionCommand())) {
                if (item.chars().allMatch(Character::isDigit))
                    calculationRepository.addNumber(Integer.parseInt(item));
                else {
                    calculationRepository.setOperator(item);
                }
            }
        }
    }
}
