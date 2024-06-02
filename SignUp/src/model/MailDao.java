package model;

import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.io.UnsupportedEncodingException;
import java.util.Properties;

public class MailDao {

    private final String ID = "ensharp123@gmail.com";
    private final String PASSWORD = "ensharp@";
    private Session session;

    public MailDao() {
        Properties properties = new Properties();
        properties.put("mail.smtp.host", "smtp.gmail.com");
        properties.put("mail.smtp.port", 465);
        properties.put("mail.smtp.auth", "true");
        properties.put("mail.smtp.ssl.trust", "smtp.gmail.com");
        properties.put("mail.smtp.ssl.enable", "true");
        properties.put("mail.smtp.starttls.enable", "true");
        properties.put("mail.smtp.ssl.protocols", "TLSv1.2");

        this.session = Session.getDefaultInstance(properties, new javax.mail.Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(ID, PASSWORD);
            }
        });
    }

    public void sendMail(String receiver) {
        try {
//            MimeMessage message = new MimeMessage(session);
//            message.setFrom(new InternetAddress(ID));
//            message.addRecipient(Message.RecipientType.TO, new InternetAddress(receiver));
//
//            message.setSubject("testMail");
//            message.setText("1234");
//
//            Transport.send(message);
            Message msg = new MimeMessage(session);
            msg.setFrom(new InternetAddress(ID, "Example.com Admin"));
            msg.addRecipient(Message.RecipientType.TO, new InternetAddress(receiver, "Mr. User"));
            msg.setSubject("testMail");
            msg.setText("This is a test");
            Transport.send(msg);
        } catch (MessagingException | UnsupportedEncodingException e) {
            e.printStackTrace();
        }
    }
}
