import java.io.DataInputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Arrays;

import org.json.JSONObject;

public class Login {

	public Login() 
	{
		ServerSocket listener = null;
        byte[] data = null;
        try {
            while (true) {
            	listener = new ServerSocket(9000);
            	
                Socket socket = listener.accept();
                System.out.println("made it this far");
                try {
                	
                	DataInputStream dIn = new DataInputStream(socket.getInputStream());
                	int length = dIn.available();                    // read length of incoming message
                	if(length>0) 
                	{
                	    data = new byte[length];
                	    dIn.readFully(data, 0, data.length); // read the message
                	    
                	    JSONObject json = new JSONObject(data + "");
                	    String username = json.getString("username");
                	    ChatClient cc = new ChatClient(socket);
            	    	
            			Server.userMap.put(username, cc);
                	    System.out.println(Arrays.toString(data));
                	    
                    	PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
                    	System.out.println(0x02); //TODO Do we want this?
                    	
                    	
                	}
                	else
                    {
                    	PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
                    	out.println("ERROR- DID NOT RECEIVE BYTES"); //TODO Do we want this?
                    }
                	
                }
                catch(Exception e){}
                /*
                finally {
                    socket.close();
                }
                */
            }
        }
        catch(Exception e)
        {}
        /*
        finally {
            try {
				listener.close();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
        }
        */
	}

}
