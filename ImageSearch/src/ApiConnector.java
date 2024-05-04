import com.sun.net.httpserver.HttpHandler;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.net.http.HttpClient;
import java.net.http.HttpHeaders;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

public class ApiConnector {
    private HttpURLConnection connection;

    public ApiConnector(String s) throws IOException {
        String query = URLEncoder.encode(s, "UTF-8");
        URL url = new URL(String.format("https://dapi.kakao.com/v2/search/image?query=%s", query));
        this.connection = (HttpURLConnection) url.openConnection();
        connection.setRequestProperty("Authorization", "KakaoAK 699379f180c3243da74ec98228683930");
        connection.setDoOutput(true);
    }

    public List<String> getImageURLs() throws ParseException {
        List<String> results = new ArrayList<>();
        StringBuffer stringBuffer = getImageStringBuffer();
        JSONObject jsonObject = (JSONObject) new JSONParser().parse(stringBuffer.toString());
        JSONArray jsonArray = (JSONArray) jsonObject.get("documents");

        for(int i = 0; i < jsonArray.size(); i++){
            JSONObject jb = (JSONObject) jsonArray.get(i);
            results.add(jb.get("image_url").toString());
        }
        return results;
    }

    private StringBuffer getImageStringBuffer() {
        StringBuffer sb = new StringBuffer();
        try{
            BufferedReader br = new BufferedReader(new InputStreamReader(connection.getInputStream(), "UTF-8"));
            while(br.ready())
                sb.append(br.readLine());
        }catch(Exception e) {
            e.printStackTrace();
        }
        return sb;
    }
}
