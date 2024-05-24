package utility;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class StringManager {

    public static String getBackspace(String str) {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < str.length(); i++) {
            result.append("\b");
        }
        return result.toString();
    }

    public static String getTimeInfo(long time) {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd a hh:mm");
        return dateFormat.format(new Date(time));
    }

    public static String getCommaNumber(long number) {
        DecimalFormat decimalFormat = new DecimalFormat("###,###");
        return decimalFormat.format(number);
    }
}
