
package oscar;

/*
* ReadFile.java
* Author: Gyüre Árpád
* Copyright: 2023, Gyüre Árpád
* Group: Szoft I-1-E
* Date: 2023-05-14
* Github: https://github.com/rp2022k/Oscar
* Licenc: GNU GPL
*/

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class ReadFile {
    
    public void ReadFile(String fileName)throws IOException{
        
        try (BufferedReader br = new BufferedReader(new FileReader (fileName))){
            int row = 0;
            String line = br.readLine();
            
            ArrayList <ArrayList<Object>> list = new ArrayList<>();
            //if first char of txt file a BOM, this row cut it
            if (line.charAt(0) != '"')
                line = br.readLine();
            
            String elem = "";
            char k;
            
            while (line != null) {
                
                for(int i = 0; i<line.length(); i++) {
                    if (i == 0) list.add(new ArrayList());
                    
                    k = line.charAt(i);
                    
                    if (k == ';'){
                        list.get(row).add(elem);
                        
                        //System.out.println(elem);
                        elem = "";
                        k = '\0';
                    }
                    if (k != '"')
                        elem = elem + k;
                }
                list.get(row).add(elem);
                elem = "";
                line = br.readLine();
                row ++;
                
            }
            br.close(); 
            
            for (int i = 0; i < list.size(); i++) {
                
                System.out.printf("%-10s",list.get(i).get(0));
                System.out.printf("%-50s",list.get(i).get(1));
                System.out.printf("%-10s",list.get(i).get(2));
                System.out.printf("%-10s",list.get(i).get(3));
                System.out.printf("%-10s",list.get(i).get(4));
                
                System.out.println();
            }
            
        } catch (IOException ex) {
            System.out.println("Error: " + ex.getMessage());
        }
        
    }
}
