using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class UIManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text recordTxt;
    public int score;
    public int recordAntigo;

    public int record;
    public  static UIManager uiManagerInstance;
    public HighscoreTable _highscoreTable;

    void Awake()
    {
        
        
        if (uiManagerInstance == null)
        {
            uiManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        record = PlayerPrefs.GetInt("record", 0);
        
        recordTxt.text = record.ToString();
        _highscoreTable =  FindObjectOfType(typeof(HighscoreTable)) as HighscoreTable;
        
        
        
    }

    public void AddScore(int points)
    {
        score += points;
        scoreTxt.text =  score.ToString();
        if(record < score)
        {
            
            record = score;
            PlayerPrefs.SetInt("record", record);
            recordTxt.text =  record.ToString();
            
            
        }
    }

    // public void AddRecordRanking()
    // {
    //     if(record > recordAntigo)
    //     {
           
    //         recordAntigo = record;
    //         PlayerPrefs.SetInt("recordAntigo", recordAntigo);
    //     }
    // }
    public void SceneNext()
    {
       
        SceneManager.LoadScene("Ranking");
        
        
    }
}
