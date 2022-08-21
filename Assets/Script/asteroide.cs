using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    public GameObject particleExplosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20 * Time.deltaTime,20 * Time.deltaTime, 0));
        
    }


    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Planeta"))
        {
            Destroy(this.gameObject);
            AudioManager.audioManagerInstace.PlayAudioOne(6);
            Instantiate(particleExplosion, transform.position, Quaternion.identity);

        }
        if(other.gameObject.CompareTag("Shield"))
        {
            Destroy(this.gameObject);
            AudioManager.audioManagerInstace.PlayAudioOne(7);
            Instantiate(particleExplosion, transform.position, Quaternion.identity);

        }
        if(other.gameObject.CompareTag("Life"))
        {
            Destroy(this.gameObject);
            AudioManager.audioManagerInstace.PlayAudioOne(7);
            Instantiate(particleExplosion, transform.position, Quaternion.identity);

        }
    }

   
}
