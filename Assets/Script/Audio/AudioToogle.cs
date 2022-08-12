using UnityEngine.UI;
using UnityEngine;


public class AudioToogle : MonoBehaviour
{


    public Toggle tMusica;
    private void Start()
    {
        tMusica = GetComponent<Toggle>();
        ToggleMusica();
    }


    public void ToggleMusica()
    {
        Debug.Log("chamou");
        if(tMusica.isOn == true)
        {
            AudioManager.audioManagerInstace.PlayAudioOne(2);
        }
        else
        {
            AudioManager.audioManagerInstace.StopMusica(2);
        }
        
            

    }





}
