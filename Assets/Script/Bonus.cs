using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    
    private UIManager _uiManager;

    private void Start() 
    {
        AudioManager.audioManagerInstace.PlayAudioOne(8);
    }
    void Update()
    {
        

        transform.position += (Vector3.left * Time.deltaTime);
        transform.Rotate(new Vector3( 0,30 * Time.deltaTime,0));
        if(transform.position.x <= -3.64f)
        {
            Destroy(this.gameObject);
        }


    }
}
