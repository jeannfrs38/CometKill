using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLife : MonoBehaviour
{
    Material materialEscudo; 
   

    
    void Start()
    {
        materialEscudo = GetComponent<MeshRenderer> ().material;
        AudioManager.audioManagerInstace.PlayAudioOne(9);
    }

    
    void Update()
    {
        materialEscudo.mainTextureOffset += new Vector2( 0, 0.5f * Time.deltaTime);
        
        Destroy(this.gameObject, 2.5f);
        

    }

    // private void OnCollisionEnter(Collision other) 
    // {
    //     if(other.gameObject.CompareTag("asteroide"))
    //     {
    //         if(life > 0)
    //         {
    //             life -=1;
    //         }
            
    //     }
    //     if(other.gameObject.CompareTag("asteroide2"))
    //     {
    //         if(life <= 3 && life > 1 )
    //         {
    //             lifeescudo -= 2;
    //         }
    //         else if( life == 1)
    //         {
    //             life -= 1;
    //         }
            
    //     }     
    // }
}
