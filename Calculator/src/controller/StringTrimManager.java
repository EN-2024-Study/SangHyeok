package controller;

import utility.Constants;

import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.DecimalFormat;

public class StringTrimManager {

    public String processComma(String str) {
        if (!str.matches(Constants.NUMBER_REGEX))
            return str;

        String number = processDecimalPoint(str);
        number = str.replaceAll(",", "");
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

    public String processE(String str) {
        String[] operators = new String[]{"\\" + Constants.ADD_STRING, Constants.SUBTRACT_STRING, "\\" + Constants.MULTIPLY_STRING, Constants.DIVIDE_STRING};
        String formula = processDecimalPoint(str);

        for (String o : operators) {
            if (formula.contains(o)) {

                if (formula.charAt(formula.length() - 1) == o.charAt(0)) {  // 식의 마지막이 연산자일 경우
                    String number = formula.substring(0, formula.length() - 1);
                    return getReplaceString(number) + o;
                }

                String[] strings = formula.split(o);
                String firstNumber = getReplaceString(strings[0]);
                String secondNumber = getReplaceString(strings[1]);
                return firstNumber + o + secondNumber;
            }
        }

        return getReplaceString(formula);
    }

    private String getReplaceString(String str) {
        if (str.length() <= Constants.NUMBER_MAX_LENGTH ||
                (str.contains(Constants.POINT_STRING) && str.length() <= Constants.NUMBER_MAX_LENGTH + 1))
            return str;

        BigDecimal bigDecimal = new BigDecimal(str);
        String result = new BigDecimal(bigDecimal.toString(), MathContext.DECIMAL64).stripTrailingZeros().toString();
        System.out.println(result);

        return result;
    }

    private String processDecimalPoint(String str) {
        if (!str.matches(Constants.NUMBER_REGEX))
            return str;

        if (!str.contains(Constants.POINT_STRING))
            return str;

        int maxSize = 17;
        int scaleSize = 16;
        BigDecimal result = new BigDecimal(str).setScale(scaleSize, RoundingMode.HALF_EVEN).stripTrailingZeros();
        String integerPart = "";

        for(int i = 0; i < result.toString().length(); i++) {
            if (result.toString().charAt(i) == '.')
                break;
            integerPart += result.toString().charAt(i);
        }
        if (integerPart.equals("0"))    // 실수부가 0이면 소수자리 개수 하나 더 늘어남
            maxSize = 18;

        while (result.toString().length() > maxSize)
            result = result.setScale(--scaleSize, RoundingMode.HALF_EVEN).stripTrailingZeros();

        return result.toPlainString();
    }
}
