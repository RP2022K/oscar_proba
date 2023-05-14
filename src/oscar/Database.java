
package oscar;

/*
* Database.java
* Author: Gyüre Árpád
* Copyright: 2023, Gyüre Árpád
* Group: Szoft I-1-E
* Date: 2023-05-14
* Github: https://github.com/rp2022k/Oscar
* Licenc: GNU GPL
*/

import java.io.*;
import java.sql.*;

public class Database {
    
    String url;
    String database;
    String user;
    String password;
    String kapcsolat;

    public Database(String url, String database, String user, String password, String kapcsolat) {
        this.url = url;
        this.database = database;
        this.user = user;
        this.password = password;
        this.kapcsolat = kapcsolat;
    }
    
    public void forceDb(String fileName) throws IOException {
        
        try {    
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException ex) {
            System.out.println("Baj van! Nem találom a driver-t!"+ ex);
        }
        if (this.kapcsolat !=null)
        {
            System.out.println("Sikeresen kapcsolódtunk az adatbázishoz \n");
        }
        
        try { 
            Connection con = DriverManager.getConnection(this.url+this.database, this.user, this.password);
            
            Statement stm = con.createStatement();
            String sql = "DROP TABLE IF EXISTS filmek";
			stm.executeUpdate(sql);
			
                   sql = "CREATE TABLE IF NOT EXISTS `filmek` (" +
                         "  `azon` varchar(15) COLLATE utf8_hungarian_ci NOT NULL," +
                         "  `cim` varchar(255) COLLATE utf8_hungarian_ci DEFAULT NULL," +
                         "  `ev` int(4) DEFAULT NULL," +
                         "  `dij` int(2) DEFAULT NULL," +
                         "  `jelol` int(2) DEFAULT NULL," +
                         "  PRIMARY KEY (`azon`)" +
                         ") ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;";
                   
                        stm.executeUpdate(sql);
                        
                   sql = "LOAD DATA INFILE "+ '"' + fileName + '"'+
                         " INTO TABLE filmek "+
                         "FIELDS TERMINATED BY ';' "+  
                         "OPTIONALLY ENCLOSED BY '\"' "+  
                         "LINES TERMINATED BY '\r\n' "+
                         "IGNORE 1 ROWS;";            
                        
                        stm.executeUpdate(sql);
                        
            System.out.println("Sikeresen betöltődött a file !\n");
            
        } catch (SQLException ex) {
            System.out.println("Baj van! Hiba az adatbázis csatlakozásban!"+ ex);
        }
    }
    
    public void showDb() throws IOException{       
        
        try {    
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException ex) {
            System.out.println("Baj van! Nem találom a driver-t!"+ ex);
        }
        if (this.kapcsolat !=null)
        {
            System.out.println("\nSikeresen kapcsolódtunk \n");
        }
        
        try { 
            Connection con = DriverManager.getConnection(this.url+this.database, this.user, this.password);
            
            Statement stm = con.createStatement();
            ResultSet rs = stm.executeQuery("SELECT * FROM oscar.filmek");
            while (rs.next()) {
                String azon = rs.getString("azon");
                String cim = rs.getString("cim");
                int ev = rs.getInt("ev");
                int dij = rs.getInt("dij");
                int jelol = rs.getInt("jelol");
                System.out.printf("%-10s%-50s%-10d%-10d%-10d\n", azon, cim, ev, dij, jelol );
         }
            
        } catch (SQLException ex) {
            System.out.println("Baj van! Hiba az adatbázis csatlakozásnban!"+ ex);
        }
        
    }
    
    public void insertDb(String azon, String cim, int ev, int dij, int jelol) throws IOException{ 
        
        try {    
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException ex) {
            System.out.println("Baj van! Nem találom a driver-t!"+ ex);
        }
        if (this.kapcsolat !=null)
        {
            System.out.println("\nSikeresen kapcsolódtunk \n");
        }
        
        try { 
            Connection con = DriverManager.getConnection(this.url+this.database, this.user, this.password);
            
            Statement stm = con.createStatement();
            
            String sql = "insert into oscar.filmek "
					+"(azon, cim, ev, dij, jelol)"
					+ " values ('"+ azon+"','"
                                                     + cim+"',"
                                                     + ev+","
                                                     + dij+","
                                                     + jelol+");";
			stm.executeUpdate(sql);
			System.out.println("Sikeres beszúrás !");
            
        } catch (SQLException ex) {
            System.out.println("Baj van! Hiba az adatbázis csatlakozásban!"+ ex);
        }
    }
    
    public void deleteDb(String azon) throws IOException{ 
        
        try {    
            Class.forName("com.mysql.cj.jdbc.Driver");
        } catch (ClassNotFoundException ex) {
            System.out.println("Baj van! Nem találom a driver-t!"+ ex);
        }
        if (this.kapcsolat !=null)
        {
            System.out.println("\nSikeresen kapcsolódtunk \n");
        }
        
        try { 
            Connection con = DriverManager.getConnection(this.url+this.database, this.user, this.password);
            
            Statement stm = con.createStatement();
            String sql = "DELETE FROM oscar.filmek WHERE azon = '" + azon + "';";
			stm.executeUpdate(sql);
			System.out.println("Sikeres törlés !");
            
        } catch (SQLException ex) {
            System.out.println("Baj van! Hiba az adatbázis csatlakozásban!"+ ex);
        }
    }
}
