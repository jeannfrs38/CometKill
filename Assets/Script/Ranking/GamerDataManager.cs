using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public  class GamerDataManager : MonoBehaviour
{
    string saveFile;
    public Highscores save;


    private  void Awake() 
    {
    
        saveFile =  Application.persistentDataPath + "/" + "highscore.json";    
        save  = new Highscores();
        
    }

    public void readFile()
    {
        if (File.Exists(saveFile))
        {
            // work with JSON
            string fileContents =  File.ReadAllText(saveFile);

            save = JsonUtility.FromJson<Highscores>(fileContents);
        }
        else 
        {

        }
    }

    public void writeFile()
    {
        string jsonString = JsonUtility.ToJson(save);


        File.WriteAllText(saveFile, jsonString);
    }


    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;

        public Highscores()
        {
            highscoreEntryList = new List<HighscoreEntry>();
        }

    }
    
}
