import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

//import javax.swing.JOptionPane;

/**
 * Trivial client for the date server.
 */
public class Client {

    /**
     * Runs the client as an application.  First it displays a dialog
     * box asking for the IP address or hostname of a host running
     * the date server, then connects to it and displays the date that
     * it serves.
     */
    public static void main(String[] args) throws IOException {
        //String serverAddress = JOptionPane.showInputDialog("localhost:9090");
    	String e = "{\"username\":\"abe\",\"opcode\":\"0x0D\"}";
    	byte[] message = e.getBytes();    	
    	
        //Socket s = new Socket("151.80.183.164", 3306);
    	Socket s = new Socket("localhost", 9090);
        DataOutputStream dOut = new DataOutputStream(s.getOutputStream());

        dOut.writeInt(message.length); // write length of the message
        dOut.write(message);           // write the message
        
        //BufferedReader input = new BufferedReader(new InputStreamReader(s.getInputStream()));
        //String answer = input.readLine();
        //System.out.println(answer);
        //JOptionPane.showMessageDialog(null, answer);
        //System.exit(0);
    }
}