import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Arrays;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;


public class Server 
{
	public static Map<String, ChatClient> userMap = new HashMap<>();
	
    public static void main(String[] args) throws IOException 
    {
    	
    	
    	
        ServerSocket listener = new ServerSocket(9090);
        
        try {
            while (true) {
            	System.out.println("waiting for connection");
                Socket socket = listener.accept();
                
                System.out.println("socket started accepting");
                try {
                	//InputStream stream = socket.getInputStream();
                	
                	DataInputStream dIn = new DataInputStream(socket.getInputStream());
                	
                	Worker worker = new Worker(dIn, socket);
                	worker.start();
                	
                	//byte[] message = null;
                	
                	/*
                	int count = 0;
                    while(count < SIZE_OF_BITE_ARRAY)
                    {
                    	data = new byte[SIZE_OF_BITE_ARRAY];
                    	count = stream.read(data);
                    }
                    if(data != null)
                    {
                    	System.out.println("HELLO");
                    	Worker worker = new Worker();
                    	worker.input = data;
                    	worker.start();
                    }
                    else
                    {
                    	PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
                    	out.println("ERROR- DID NOT RECEIVE BYTES"); //TODO Do we want this?
                    }
                    */
                	
                }
                catch(Exception e){
                	System.out.println(e);
                }
                finally {
                	System.out.println("Shit3");
                    //socket.close();
                }
            }
        }
        catch(Exception e)
        {
        	System.out.println(e);
        }
        finally {
        	System.out.println("Shit");
            listener.close();
        }
    }
}