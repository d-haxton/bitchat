import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.net.Socket;
import java.util.HashMap;
import java.util.Map;

public class ChatClient 
{
	Socket socket;
	public ChatClient(Socket socket) 
	{
		this.socket = socket;
	}
	
	public void send(byte[] data)
	{
        DataOutputStream dOut;
        try
        {
        dOut = new DataOutputStream(socket.getOutputStream());

        //dOut.writeInt(data.length); // write length of the message
        dOut.write(data, 0, data.length);           // write the message
        dOut.flush();
        
        System.out.println("Passed Message.");        
        }
        catch(Exception ex)
        {
        	System.out.println(ex);
        }
        finally
        {
        	//System.exit(0);
        }
        
	}

	
}
