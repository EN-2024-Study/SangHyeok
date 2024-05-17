package controller;

import utility.Constants;

import java.math.BigDecimal;
import java.math.MathContext;
import java.text.DecimalFormat;

public class StringTrimManager {

    public String processComma(String number) {
        if (number.equals(Constants.WRONG_DIVIDED1) || number.equals(Constants.WRONG_DIVIDED2) ||
                number.equals(Constants.OVERFLOW))
            return number;

        String integerPart = "";
        String decimalPart = "";
        boolean isPoint = false;

        for (int i = 0; i < number.length(); i++) {
            if (number.charAt(i) == '.')
                isPoint = true;

            if (isPoint)
                decimalPart += number.charAt(i);
            else
                integerPart += number.charAt(i);
        }
        integerPart = integerPart.replace("--", "-");

        BigDecimal bigDecimal = new BigDecimal(integerPart);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        if (isPoint)
            return decimalFormat.format(bigDecimal) + decimalPart;
        return decimalFormat.format(bigDecimal);
    }

    public String processE(String number) {
        if (number.equals(" ") || number.equals(Constants.WRONG_DIVIDED1) || number.equals(Constants.WRONG_DIVIDED2))
            return number;

        if (number.contains("negate("))
            return number;

        String[] operators = Constants.OPERATORS;
        for (String o : operators) {
            if (number.contains(o)) {
                if (number.charAt(0) == o.charAt(0))
                    continue;

                if (number.charAt(number.length() - 1) == o.charAt(0))   // 식의 마지막이 연산자일 경우
                    return getReplaceString(number.substring(0, number.length() - 1)) + o;
                else if (o.equals(Constants.ADD_STRING)) {
                    String[] str = number.split("\\+");
                    String firstNum = getReplaceString(str[0]);
                    String secondNum = getReplaceString(str[1].substring(0, str[1].length() - 1));
                    return firstNum + o + secondNum + Constants.EQUAL_STRING;
                }

                String[] strings = number.split(o);
                String firstNumber = getReplaceString(strings[0]);
                String secondNumber = getReplaceString(strings[1].substring(0, strings[1].length() - 1));
                return firstNumber + o + secondNumber + Constants.EQUAL_STRING;  // number operator number = 일 경우
            }
        }

        return getReplaceString(number);    // 숫자만 존재할 경우
    }

    private String getReplaceString(String number) {
        number = processDecimalPoint(number);
        if (!isOverLength(number))
            return number;

        number = number.replace(",", "");

        BigDecimal bigDecimal = new BigDecimal(number);
        String result = new BigDecimal(bigDecimal.toString(), MathContext.DECIMAL64).stripTrailingZeros().toString();
        return result.replace("E", "e");
    }

    private String processDecimalPoint(String number) {
        if (!number.contains(Constants.POINT_STRING))
            return number;

        number = number.replace(",", "");
        BigDecimal result = new BigDecimal(number).stripTrailingZeros();
        return result.toPlainString();
    }

    private boolean isOverLength(String checkString) {
        checkString = checkString.replace(",", "");
        checkString = checkString.replace(".", "");
        if (checkString.length() <= Constants.NUMBER_MAX_LENGTH)
            return false;
        return true;
    }
}
