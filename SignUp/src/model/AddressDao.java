package model;

import constant.APITexts;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

import static java.lang.System.getenv;

public class AddressDao implements IAddress {

    private final String apiKey;
    private HttpURLConnection connection;

    public AddressDao() {
        this.apiKey = getenv().get(APITexts.API_KEY);
        this.connection = null;
    }

    @Override
    public String searchAddress(String query) {
        try {
            int responseCode = getResponseCode(query);
            if (responseCode != 200) {
                return null;
            }

            JSONArray jsonArray = getJSONArray();
            if (jsonArray.isEmpty()) {
                return null;
            }

            JSONObject addressInfo = jsonArray.getJSONObject(0);
            String addressType = addressInfo.getString(APITexts.ADDRESS__TYPE);
            if (!addressType.equals(APITexts.REGION_ADDR) && !addressType.equals(APITexts.ROAD_ADDR)) {
                return null;
            }

            return addressInfo.getString(APITexts.ADDRESS_NAME);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    private int getResponseCode(String query) throws IOException {
        String encodedQuery = URLEncoder.encode(query, APITexts.encoding);
        URL url = new URL(APITexts.URL + APITexts.QUERY + encodedQuery);

        connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod(APITexts.GET);
        connection.setRequestProperty(APITexts.AUTHORIZATION, APITexts.KAKAOAK + apiKey);

        return connection.getResponseCode();
    }

    private JSONArray getJSONArray() throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
        StringBuilder response = new StringBuilder();
        String line;

        while ((line = reader.readLine()) != null) {
            response.append(line);
        }

        JSONObject jsonObject = new JSONObject(response.toString());
        return jsonObject.getJSONArray(APITexts.DOCUMENT);
    }
}
