using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    
    public static AudioManager audioManagerInstace;

    public List<AudioSource> audios = new List<AudioSource>();
    
    


    public float fadeTime;
    
    // public Slider sliderEfeito;
    
    
    void Awake()
    {
        if (audioManagerInstace == null)
        {
            audioManagerInstace = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
       
       

    }


    private void Update()
    {
        
        
    }

    public void PlayAudioOne(int index)
    {
          
                audios[index].Play();
            

            

    }
    public void PlayAudioThree(int index)
    {

            audios[index].Play();
           

    }
    // public void PlayAudioFour()
    // {

    //         audioFour.Play();
           

    // }
    // public void PlayAudioFive()
    // {

    //     audioFive.Play();


    // }

    // public void PlayAudioTwo(int index)
    // {
        
    //     if (audios[index].isPlaying == false )
    //     {
            
    //        audios[index].Play();
    //        audios[index].volume = 0;
            
    //     //    StartCoroutine(FadeIn(audios[index], fadeTime, volume));

    //     }

    // }
    public void StopMusica(int index)
    {
        // StartCoroutine(FadeOut(audios[index], 0.1f));
    //      volume = audios[index].volume;
            audios[index].Stop();
    }
    public void StopEffect(int index)
    {
        audios[index].Stop();
    }



    // public static IEnumerator FadeIn(AudioSource audiosource, float FadeTime, float volume)
    // {
    //     while(audiosource.volume < 1f){
    //         audiosource.volume += 0.1f * Time.deltaTime / FadeTime;

    //         yield return null;
    //     }
    // }

    // public static IEnumerator FadeOut(AudioSource audiosource, float FadeOut)
    // {
    //     while(audiosource.volume > 0.00f)
    //     {
    //         audiosource.volume -= 0.1f * Time.deltaTime / FadeOut;
    //         yield return null;
    //     }
    //     audiosource.Stop();
    // }

  

}
