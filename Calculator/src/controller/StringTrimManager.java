package controller;

import utility.Constants;

import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.DecimalFormat;

public class StringTrimManager {

    public String processComma(String number) {
        if (number.equals(Constants.WRONG_DIVIDED1) || number.equals(Constants.WRONG_DIVIDED2))
            return number;

        String integerPart = "";
        String decimalPart = "";
        boolean isPoint = false;

        for(int i = 0; i < number.length(); i++) {
            if (number.charAt(i) == '.')
                isPoint = true;

            if (isPoint)
                decimalPart += number.charAt(i);
            else
                integerPart += number.charAt(i);
        }

        BigDecimal bigDecimal = new BigDecimal(integerPart);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        if (isPoint)
            return decimalFormat.format(bigDecimal) + decimalPart;
        return decimalFormat.format(bigDecimal);
    }

    public String processE(String number) {
        if (number.isEmpty() || number.equals(Constants.WRONG_DIVIDED1) || number.equals(Constants.WRONG_DIVIDED2))
            return number;

        String[] operators = new String[]{"\\" + Constants.ADD_STRING, Constants.SUBTRACT_STRING, "\\" + Constants.MULTIPLY_STRING, Constants.DIVIDE_STRING};
        for (String o : operators) {
            if (number.contains(o)) {
                if (number.charAt(0) == o.charAt(0))
                    continue;

                if (number.charAt(number.length() - 1) == o.charAt(0))   // 식의 마지막이 연산자일 경우
                    return getReplaceString(number.substring(0, number.length() - 1)) + o;

                String[] strings = number.split(o);
                String firstNumber = getReplaceString(strings[0]);
                String secondNumber = getReplaceString(strings[1]);
                return firstNumber + o + secondNumber;  // number operator number = 일 경우
            }
        }

        return getReplaceString(number);    // 숫자만 존재할 경우
    }

    private String getReplaceString(String number) {
        number = processDecimalPoint(number);

        if (number.length() <= Constants.NUMBER_MAX_LENGTH ||
                (number.contains(Constants.POINT_STRING) && number.length() <= Constants.NUMBER_MAX_LENGTH + 1))
            return number;

        BigDecimal bigDecimal = new BigDecimal(number);
        return new BigDecimal(bigDecimal.toString(), MathContext.DECIMAL64).stripTrailingZeros().toString();
    }

    private String processDecimalPoint(String number) {
        if (!number.contains(Constants.POINT_STRING))
            return number;

        int scaleSize = 16;
        String integerPart = "";

        for(int i = 0; i < number.length(); i++) {
            if (number.charAt(i) == '.')
                break;
            integerPart += number.charAt(i);
        }

        if (integerPart.equals("0"))
            scaleSize = 17;

        BigDecimal result = new BigDecimal(number).setScale(scaleSize, RoundingMode.HALF_EVEN).stripTrailingZeros();
        return result.toPlainString();
    }
}
