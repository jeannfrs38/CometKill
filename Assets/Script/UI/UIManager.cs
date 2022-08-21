
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


    public GameObject buttonShield;
    public GameObject buttonLife;
    public int score;
    public int recordAntigo;

    public float valueTimeScale;
    public GameObject panelPause;
  
    public int record;
    public  static UIManager uiManagerInstance;

    private Planeta _planeta;
    private SpanwBonus _spawnBonus;
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
        _spawnBonus = FindObjectOfType(typeof(SpanwBonus)) as SpanwBonus;
        
        
        
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

        valueTimeScale =  Time.timeScale; 

        Debug.Log(valueTimeScale);
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
            Time.timeScale = valueTimeScale;
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
     
     public void  ButtonBonusShield()
     {
        if(buttonShield.gameObject.activeSelf == true)
        {
            buttonShield.gameObject.SetActive(false);
            
        }
        else if(buttonShield.gameObject.activeSelf == false)
        {
            buttonShield.gameObject.SetActive(true);
            
        }
     }
     public void  ButtonBonusLife()
     {
        if(buttonLife.gameObject.activeSelf == true)
        {
            buttonLife.gameObject.SetActive(false);
            
        }
        else if(buttonLife.gameObject.activeSelf == false)
        {
            buttonLife.gameObject.SetActive(true);
            
        }
     }

     public void RandomIntervalo()
     {
        _spawnBonus.intervalo = _spawnBonus.RandomNumber(30, 240);
    

       
     }
     public void RandomIntervalo2()
     {
        _spawnBonus.intervalo2 = _spawnBonus.RandomNumber(30, 240);
    
        
       
     }
}
     
