using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public GameObject panelSound;
    public GameObject panelMenu;
    public  static UIMenu uiMenuInstance;
    public AudioMixer audioMixer;
    public AudioMixer audioMixerEff;
    public string volumeParameter = "volume";
    public string volumeParameterEff = "effects";
    public Slider sliderMusic;
     public Slider sliderEffect;

    public float volumef;
    public float volumeEffects;
    
    void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat(volumeParameter, sliderMusic.value);
        sliderEffect.value = PlayerPrefs.GetFloat(volumeParameterEff, sliderEffect.value);
        Time.timeScale = 1f;
        if (uiMenuInstance == null)
        {
            uiMenuInstance = this;
            // DontDestroyOnLoad(this.gameObject);
           
        }
        
       
    }
     private void OnDisable() 
    {
        PlayerPrefs.SetFloat(volumeParameter, sliderMusic.value);    
        PlayerPrefs.SetFloat(volumeParameterEff, sliderEffect.value); 
    }
    // Update is called once per frame
     private void Update()
    {
          sliderMusic.value = volumef;
          
    }

     public void SceneNext(string scene)
    {
       
        SceneManager.LoadScene(scene);
        
        
        
    }
    public void SoundPanel()
    {
        if (panelSound.gameObject.activeSelf == true)
        {
            panelSound.gameObject.SetActive(false);
            panelMenu.gameObject.SetActive(true);
            
            
        }
        else if (panelSound.gameObject.activeSelf ==  false)
        {
            
            panelSound.gameObject.SetActive(true);
            panelMenu.gameObject.SetActive(false);
            
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SceneMenu(string scene)
    {
       
        SceneManager.LoadScene(scene);
        
        
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(volumeParameter, volume);
        volumef =  volume;
        
    }
    public void SetVolumeEff(float volumeEff)
    {
        audioMixerEff.SetFloat(volumeParameterEff, volumeEff);
        volumeEffects =  volumeEff;
        
    }
    public void SetSliderValue()
    {
        sliderMusic.value = volumef;
    }
    public void SetSliderValueEff()
    {
        sliderEffect.value = volumeEffects;
    }
    public void SetMusic(int index)
    {
        AudioManager.audioManagerInstace.PlayAudioOne(index);
    }public void StopMusic(int index)
    {
        AudioManager.audioManagerInstace.StopMusica(index);
    }
    
}
