package model;

import constant.APIConstants;
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
        this.apiKey = getenv().get(APIConstants.API_KEY);
    }

    @Override
    public String searchAddress(String query) {
        try {
            String encodedQuery = URLEncoder.encode(query, APIConstants.encoding);
            URL url = new URL(APIConstants.URL + APIConstants.QUERY + encodedQuery);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod(APIConstants.GET);
            connection.setRequestProperty(APIConstants.AUTHORIZATION, APIConstants.KAKAOAK + apiKey);

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
            JSONArray jsonArray = jsonObject.getJSONArray(APIConstants.DOCUMENT);

            if (jsonArray.isEmpty()) {
                return null;
            }

            JSONObject addressInfo = jsonArray.getJSONObject(0);
            return addressInfo.getString(APIConstants.ADDRESS_NAME);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }
}
