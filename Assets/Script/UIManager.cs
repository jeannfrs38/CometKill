
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text recordTxt;
    public int score;
    public int recordAntigo;
    public GameObject panelPause;
  
    public int record;
    public  static UIManager uiManagerInstance;
    public AudioMixer audioMixer;
    public AudioMixer audioMixerEff;
     public string volumeParameter = "volume";
     public string volumeParameterEff = "effects";
    

    void Awake()
    {
       
        if (uiManagerInstance == null)
        {
            uiManagerInstance = this;
            // DontDestroyOnLoad(this.gameObject);
           
        }
        // else
        // {
        //     Destroy(gameObject);
        // }

        
        
        record = PlayerPrefs.GetInt("record", 0);
       
        recordAntigo = PlayerPrefs.GetInt("recordAntigo", 0);
        
        recordTxt.text = record.ToString();

        
        
        
    }

    public void AddScore(int points)
    {
        score += points;
        scoreTxt.text =  score.ToString();
        if(record < score)
        {
            recordAntigo = record;
            PlayerPrefs.SetInt("recordAntigo", recordAntigo);
            record = score;
            PlayerPrefs.SetInt("record", record);
            recordTxt.text =  record.ToString();
            
            
        }
    }

    private void Update() 
    {
         if( recordTxt == null && scoreTxt == null)
        {
            score = 0;
            recordTxt = GameObject.Find("RecordTxt").GetComponent<Text> ();
            scoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text> ();
           
        }
    }
    public void SceneNext(string scene)
    {
       
        SceneManager.LoadScene(scene);
        
        
        
    }


    public void PausePanel()
    {
        if (panelPause.gameObject.activeSelf == true)
        {
            panelPause.gameObject.SetActive(false);
            Time.timeScale = 1f;
            AudioManager.audioManagerInstace.PlayAudioOne(2);
            
        }
        else if (panelPause.gameObject.activeSelf ==  false)
        {
            
            panelPause.gameObject.SetActive(true);
            Time.timeScale = 0f;
            AudioManager.audioManagerInstace.PlayAudioOne(2);
        }
    }
    

     public void ExitGame()
    {
        Application.Quit();
    }

    public void AudioSet(int index)
    {
    
       AudioManager.audioManagerInstace.PlayAudioOne(index);
    }
    public void AudioSetStop(int index)
    {
       AudioManager.audioManagerInstace.StopMusica(index);
    }
     
}
     
