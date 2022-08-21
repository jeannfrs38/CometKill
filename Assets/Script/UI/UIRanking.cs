using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIRanking : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerEff;
    public void SceneLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void SetMusic(int index)
    {
        AudioManager.audioManagerInstace.PlayAudioOne(index);
    }public void StopMusic(int index)
    {
        AudioManager.audioManagerInstace.StopMusica(index);
    }
}
