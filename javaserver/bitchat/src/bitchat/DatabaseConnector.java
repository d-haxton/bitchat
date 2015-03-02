import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;
 
public class DatabaseConnector {
 
	

    String url = "jdbc:mysql://151.80.183.164:3306/btchat";
    String user = "bitchat";
    String password = "bitchat";
    
    public void viewVersion()
    {
    	Connection con = null;
        Statement st = null;
        ResultSet rs = null;
 
        try {
            con = DriverManager.getConnection(url, user, password);
            st = con.createStatement();
            //rs = st.executeQuery("SELECT btchat");
            rs = st.executeQuery("SHOW TABLES;");
            rs = st.executeQuery("SELECT * FROM user;");

            if (rs.next()) {

            		System.out.println(rs.getString("username"));
            	
            }

        } catch (SQLException ex) {
            Logger lgr = Logger.getLogger(DatabaseConnector.class.getName());
            lgr.log(Level.SEVERE, ex.getMessage(), ex);
 
        } finally {
            try {
                if (rs != null) {
                    rs.close();
                }
                if (st != null) {
                    st.close();
                }
                if (con != null) {
                    con.close();
                }
 
            } catch (SQLException ex) {
                Logger lgr = Logger.getLogger(DatabaseConnector.class.getName());
                lgr.log(Level.WARNING, ex.getMessage(), ex);
            }
        }
    }
    
    
    public void insert(String dbName)
    {
    	Connection con = null;
        Statement st = null;
        //ResultSet rs = null;
 
        Statement stmt = null;
        String query = "select COF_NAME, SUP_ID, PRICE, " +
                       "SALES, TOTAL " +
                       "from " + dbName + ".COFFEES";
        try {
            stmt = con.createStatement();
            ResultSet rs = stmt.executeQuery(query);
            while (rs.next()) {
                String coffeeName = rs.getString("COF_NAME");
                int supplierID = rs.getInt("SUP_ID");
                float price = rs.getFloat("PRICE");
                int sales = rs.getInt("SALES");
                int total = rs.getInt("TOTAL");
                System.out.println(coffeeName + "\t" + supplierID +
                                   "\t" + price + "\t" + sales +
                                   "\t" + total);
            }
        } 
        catch (SQLException e ) 
        {
            
        } finally 
        {
            if (stmt != null) { try {
				stmt.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} }
        }
    }
    public void insertion(byte[] variables, byte[] values, String table)
    {
    	Connection con = null;
        Statement st = null;
        ResultSet rs = null;
 
        try {
            con = DriverManager.getConnection(url, user, password);
            st = con.createStatement();
            //rs = st.executeQuery("SELECT btchat");
            String query = "INSERT INTO " + table + " (";
            for(int i = 0; i < variables.length; i++)
            {
            	query += variables[i] + "";
            	if(i != variables.length -1)
            	{
            		query += ", ";
            	}
            }
            query += ") VALUES (\'";
            for(int i = 0; i < values.length; i++)
            {
            	query += values[i] + "";
            }
            int a = st.executeUpdate("INSERT INTO user (id, username, password, publickey) VALUES (\'5\',\'Nobody\',\'fdgdf\',\'24654234236\');");

            
        } catch (SQLException ex) {
            Logger lgr = Logger.getLogger(DatabaseConnector.class.getName());
            lgr.log(Level.SEVERE, ex.getMessage(), ex);
 
        } finally {
            try {
                if (rs != null) {
                    rs.close();
                }
                if (st != null) {
                    st.close();
                }
                if (con != null) {
                    con.close();
                }
 
            } catch (SQLException ex) {
                Logger lgr = Logger.getLogger(DatabaseConnector.class.getName());
                lgr.log(Level.WARNING, ex.getMessage(), ex);
            }
        }
    }
}