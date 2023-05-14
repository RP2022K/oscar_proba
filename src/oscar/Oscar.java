
package oscar;

/*
* Oscar.java
* Author: Gyüre Árpád
* Copyright: 2023, Gyüre Árpád
* Group: Szoft I-1-E
* Date: 2023-05-14
* Github: https://github.com/rp2022k/Oscar
* Licenc: GNU GPL
*/

import java.io.IOException;

public class Oscar {

    public static void main(String[] args) throws IOException {
        
        String fileName = args[0];
        
        String flag = "";
        if (args.length == 2)
            flag = args[1];
        
        String url = "jdbc:mysql://127.0.0.1:3306/";
        String dbName = "oscar";
        String user = "root";
        String password = "";
        String kapcsolat = "";
        
        Database db = new Database(url,dbName, user, password, kapcsolat);
        ReadFile rf = new ReadFile();
            if ("-f".equalsIgnoreCase(flag) || "--force".equalsIgnoreCase(flag))
            {
                System.out.println("Megadtál egy --force vagy -f flag-et,");
                System.out.println("ezért az adatbázis tartalma törlődik és a megadott file töltődik be !");
                System.out.println();
                db.forceDb(fileName);
                rf.ReadFile(fileName);
            }
        
        //rf.ReadFile(fileName);
        db.showDb();
        db.insertDb("abia62", "Lawrence of Arabia", 1962, 7, 10);
        db.showDb();
        db.deleteDb("abia62");
        db.showDb();
    }
    
}
