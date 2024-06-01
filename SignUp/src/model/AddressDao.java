package model;

import constant.APITexts;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

import static java.lang.System.getenv;

public class AddressDao implements IAddress {

    private final String apiKey;

    public AddressDao() {
        this.apiKey = getenv().get(APITexts.API_KEY);
    }

    @Override
    public String searchAddress(String query) {
        try {
            String encodedQuery = URLEncoder.encode(query, APITexts.encoding);
            URL url = new URL(APITexts.URL + APITexts.QUERY + encodedQuery);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod(APITexts.GET);
            connection.setRequestProperty(APITexts.AUTHORIZATION, APITexts.KAKAOAK + apiKey);

            int responseCode = connection.getResponseCode();
            if (responseCode != 200) {
                return null;
            }

            BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            StringBuilder response = new StringBuilder();
            String line;
            while ((line = reader.readLine()) != null) {
                response.append(line);
            }

            //===== JSON 파싱 =====//
            JSONObject jsonObject = new JSONObject(response.toString());
            JSONArray jsonArray = jsonObject.getJSONArray(APITexts.DOCUMENT);

            if (jsonArray.isEmpty()) {
                return null;
            }

            JSONObject addressInfo = jsonArray.getJSONObject(0);
            return addressInfo.getString(APITexts.ADDRESS_NAME);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
}
