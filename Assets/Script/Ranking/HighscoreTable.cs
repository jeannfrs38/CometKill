using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighscoreTable : MonoBehaviour
{
   
    private Transform entryContainer;
    private Transform entryTemplate;
     string saveFile;
    private Highscores save;
    private List<Transform> highscoreEntryTransformList;


    public void Awake()
    {
        
        saveFile =  Application.persistentDataPath + "/" + "highscore.json";
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        save = new Highscores();
        LoadPlayerData();
        VerificateScore();
        

        









            // Sort entry list by score
            for (int i = 0; i < save.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j <  save.highscoreEntryList.Count; j++)
                {
                    if(save.highscoreEntryList[j].Score > save.highscoreEntryList[i].Score)
                    {
                        // Swap
                        HighscoreEntry tmp = save.highscoreEntryList[i];
                        save.highscoreEntryList[i] =  save.highscoreEntryList[j];
                        save.highscoreEntryList[j] = tmp;
                    }

                }
            }
            for (int i = 0; i < save.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j <  save.highscoreEntryList.Count - 1 ; j++)
                {
                    if(save.highscoreEntryList[i].Name == save.highscoreEntryList[j].Name && save.highscoreEntryList[j].Score <= save.highscoreEntryList[i].Score )
                    {
                        save.highscoreEntryList.Remove(save.highscoreEntryList[j]);
                       

                    }

                }
            }

             highscoreEntryTransformList = new List<Transform>();
            foreach(HighscoreEntry highscoreEntry in save.highscoreEntryList)
            {
                    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
       SaveFile();

    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList )
    {
            float templateHeight = 100f;
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;

            switch (rank)
            {
                default:
                    rankString = rank + "TH";break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ST"; break;
                case 3: rankString = "3ST"; break;
            }

            entryTransform.Find("posText").GetComponent<Text>().text = rankString;

            int score = highscoreEntry.Score;
             entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = highscoreEntry.Name;
             entryTransform.Find("nameText").GetComponent<Text>().text = name;

            entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

            if (rank == 1)
            {
                entryTransform.Find("posText").GetComponent<Text>().color =  Color.yellow;
                 entryTransform.Find("scoreText").GetComponent<Text>().color = Color.yellow;
                  entryTransform.Find("nameText").GetComponent<Text>().color = Color.yellow;
            }if(rank != 1 && name == "YOU")
            {
                entryTransform.Find("posText").GetComponent<Text>().color =  Color.green;
                 entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
                  entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
            }
             transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score, string name)
    {

        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { Score = score, Name = name };


        LoadPlayerData();
        // Add new entry to Highscores

        save.highscoreEntryList.Add(highscoreEntry);
        // Saved file
        SaveFile();

    }

    public void VerificateScore()
    {
        int record =  PlayerPrefs.GetInt("record");


            AddHighscoreEntry(record, "YOU");
           

    }
   private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;

        public Highscores()
        {
            highscoreEntryList = new List<HighscoreEntry>();
        }

    }
    [System.Serializable]
    public class HighscoreEntry
    {
        public int Score;
        public string Name;

    }
    public void LoadPlayerData()
    {
        if (File.Exists(saveFile))
        {
                if(Application.platform == RuntimePlatform.Android)
            {
                save.highscoreEntryList  = new List<HighscoreEntry>();
                string path =  Path.Combine(saveFile);
                string jsonString = File.ReadAllText(path);


                // WWW reader = new WWW(path);
                // while (!reader.isDone) { }
                // jsonString = reader.text;
                if (jsonString != null || jsonString != "")
                {

                    Highscores temp  = JsonUtility.FromJson<Highscores>(jsonString);
                    Debug.Log("Dados carregados:\n" + jsonString);
                    if(temp != null)
                    {
                        save = temp;
                        Debug.Log("Dados carregados com sucesso");
                    }

                    else
                    {
                        Debug.Log("Erro ao carregar os dados: Nenhum elemento na lista");

                    }
                }
            }else
            {
                save.highscoreEntryList  = new List<HighscoreEntry>();

                string path =  Path.Combine(saveFile);
                string jsonString = File.ReadAllText(path);

                if (jsonString != null || jsonString != "")
                {

                    Highscores temp  = JsonUtility.FromJson<Highscores>(jsonString);
                    Debug.Log("Dados carregados:\n" + jsonString);
                    if(temp != null)
                    {
                        save = temp;
                        Debug.Log("Dados carregados com sucesso");
                    }

                    else
                    {
                        Debug.Log("Erro ao carregar os dados: Nenhum elemento na lista");

                    }
                }
                else
                {
                    Debug.Log("Erro ao carregar os dados:\n" + jsonString);
                }

            }

        }else 
        {
           save.highscoreEntryList = new List<HighscoreEntry>()
           {
                new HighscoreEntry{ Score =  875800, Name = "AAA"},
                new HighscoreEntry{ Score =  840000, Name = "JEA"},
                new HighscoreEntry{ Score =  782100, Name = "ANN"},
                new HighscoreEntry{ Score =  17100, Name = "SAM"},
                new HighscoreEntry{ Score =  16700, Name = "CAR"},
                new HighscoreEntry{ Score =  15300, Name = "FEP"},
                new HighscoreEntry{ Score =  11100, Name = "ANA"},
                new HighscoreEntry{ Score =  10000, Name = "JAN"},
                new HighscoreEntry{ Score =  9000, Name = "CAL"},
           };
            
            SaveFile();
        }
         

    }

    private void SaveFile()
    {

        string path =  Path.Combine(saveFile);
        string json = JsonUtility.ToJson(save, true);

        File.WriteAllText(path, json);

    }




}
