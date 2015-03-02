import java.io.DataInputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Arrays;

import org.json.*;

public class Worker extends Thread
{

	public DataInputStream input;
	public Socket socket;
	byte[] data = null;
	int calls= 0;
	public Worker(DataInputStream input, Socket socket)
	{
		this.input = input;
		this.socket = socket;
	}
	/*
	 * OPCodes
0x0A - Registration - 1 Delimited string via json. Variables string publickey, username
0x0B - RegistrationHandshake - Server encrypts and sends back random variable x encrypted as acknowledgement
0x0C - RegistrationConfirmation - client sends decrypted int(4 bytes) back to server
0x0D - Login - 1 delimited string via json. Variables string username
0x0F - LoginVerify - Server encrypts and sends back random variable x encrypted
0x10 - LoginConfirmation - client sends decrypted int (4 bytes) back to server
0x11 - FriendsListRequest - client requests all friends for username (sent as string)
0x12 - FriendsListConfirm - server sends json array as string of all friends usernames(encrypted)
0x13 - AddFriend - client sends json "username":username "friendId":friendId where friendID is encrypted text
0x14 - OpenChat - json "username":username "personToChat":personToChat
0x15 - ChatOpened - server sends this opcode to personToChat with username to initalize new chat
0x16 - Message - json "username":username "encryptedText":encryptedText
	 * (non-Javadoc)
	 * @see java.lang.Thread#run()
	 */
	public void run()
	{
		DataInputStream dIn = input;
		while(socket.isConnected())
		{
			try{
				int length = dIn.available();                    // read length of incoming message
				if(length>0) 
				{
					data = new byte[length];
					dIn.readFully(data, 0, data.length); // read the message
					//System.out.println(Arrays.toString(data));
					String dataString = new String(data);

					parse(dataString, data);

					System.out.println("Worker started");
				}
				else
				{
					//PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
					//out.println("ERROR- DID NOT RECEIVE BYTES"); //TODO Do we want this?
				}
			}
			catch(Exception e)
			{}
		}


	}
	public void sendToDatabase()
	{

	}
	public void queryFriends()
	{

	}
	public void passOn()
	{

	}
	public void parse(String input, byte[] data){
		System.out.println("calls:" + calls++);
		//Do what needs to be done

		System.out.println(input);
		String username = "";
		String publicKey = "";
		String chatterID = "";
		String encryptedText = null;
		String temp = "";
		String messageType = "";
		
		// Parse the data
		// opcode 0x0d = login
		JSONObject json = null;
		try 
		{
			String s = new String(input);
			json = new JSONObject(s);
			temp = json.getString("opcode");
		} 
		catch (JSONException e) 
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		if(temp.equals("0x0A"))
		{

		}
		else if(temp.equals("0x0B"))
		{

		}
		else if(temp.equals("0x0C"))
		{

		}
		else if(temp.equals("0x0D"))
		{
			try{
			username = json.getString("username");
			System.out.println(username);
			temp = json.getString("opcode");
			
			ChatClient cc = new ChatClient(socket);
			Server.userMap.put(username, cc);
			PrintWriter out;
			// python needs to be called to generate an encrypted number
			out = new PrintWriter(socket.getOutputStream(), true);
			//out.println("OK");
			}
			catch (Exception e) 
			{
				e.printStackTrace();
			}


		}
		else if(temp.equals("0x0F"))
		{

		}
		else if(temp.equals("0x10"))
		{

		}
		else if(temp.equals("0x11"))
		{

		}
		else if(temp.equals("0x12"))
		{

		}
		else if(temp.equals("0x13"))
		{

		}
		else if(temp.equals("0x14"))
		{

		}
		else if(temp.equals("0x15"))
		{

		}
		else if(temp.equals("0x16"))
		{
			// parse the rest of the data username, publickey
			// Pretend that the parse results the username = david
			//"publicKey":publicKey,"username":username,"encryptedText":encryptedText,"chatterID":chatterID
			try{
				username = json.getString("username");
				publicKey = json.getString("publicKey");
				encryptedText = json.getString("encryptedText");
				chatterID = json.getString("chatterID");
				messageType = json.getString("messageType");
				System.out.println("username: " + username + " | encrypted: " + (encryptedText));
			}
			catch(Exception e){
				System.out.println(e);
			}
			ChatClient cc = Server.userMap.get(chatterID);

			// parse the data 
			// opcode message
			// parse the username
			// username of the person you want to send to is evan
			if(cc == null)
			{
				System.out.println("User is not connected");
				// evan is not connected
				//return;
			}
			// get the encryptedmessage

			// send encrypted message to user

			cc.send(this.data);
		}
	}
}
