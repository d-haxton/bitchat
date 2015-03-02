import java.io.DataInputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class Driver {

	public static void main(String[] args) 
	{
		
		//DatabaseConnector db = new DatabaseConnector();
		//db.insertion();
		//ServerSocket listener;
		//try 
		{
			
			
			//listener = new ServerSocket(9090);
			//Socket socket = listener.accept();
			//DataInputStream dIn = new DataInputStream(socket.getInputStream());
			//int length = dIn.available();     
			
			String s = "{\"username\":\"david\"}";
			byte[] bytes = s.getBytes();
			//System.out.println(bytes.toString() + "");
			String e = "{\"opcode\":\"0x0D\"";
			byte[] data = e.getBytes();
			byte[] combined = new byte[data.length + bytes.length];
			
			String a = new String(data);
			System.out.println(a);
			
			//Worker worker = new Worker(combined, socket);
			
		} 
		//catch (IOException e) 
		//{
			//e.printStackTrace();
			
			
		//}
		
		
	}

}
