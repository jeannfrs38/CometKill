using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : MonoBehaviour
{
    Material materialEscudo; 
    MeshRenderer meshEscudo;
    public Material[] materiais;
    public Vector2 offset;
    private UIManager _uiManager;
    public int lifeEscudo;
    public int intervalo;
     public float lifeT;
    public float timeShield;

    public bool colisionAS;
    void Start()
    {
         AudioManager.audioManagerInstace.PlayAudioOne(10);
         meshEscudo = GetComponent<MeshRenderer>();

        lifeEscudo = 3;
        _uiManager = FindObjectOfType(typeof(UIManager))as UIManager;
    }

    
    void Update()
    {
        
       
        if(lifeEscudo == 0)
        {
            Destroy(this.gameObject, 0.2f);
            AudioManager.audioManagerInstace.StopEffect(10);

        }
        if(lifeEscudo == 1)
        {

           meshEscudo.material = new Material(materiais[1]);

        }
        if(lifeEscudo == 2)
        {
            meshEscudo.material =  new Material(materiais[0]);
            
            
           
        }
        if(this.gameObject.activeSelf == true)
        {
            lifeT += Time.deltaTime; 
            LifeTime();
        }
         
        
        
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("asteroide"))
        {
            colisionAS = true;
            if(lifeEscudo > 0)
            {
                lifeEscudo -= 1;
            }
            
        }
        if(other.gameObject.CompareTag("asteroide2"))
        {
            colisionAS = true;
            if( lifeEscudo > 0)
            {
                lifeEscudo -= 1;
            }
            
        }     
    }

    private void LifeTime()
    {
          
            if(lifeT == intervalo / 2)
            {
                lifeEscudo = 1;
            }
            else if(lifeT >= intervalo)
            {
                lifeEscudo = 0;
                
            }

        
    }
}
