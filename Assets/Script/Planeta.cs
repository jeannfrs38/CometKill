using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planeta : MonoBehaviour
{
    public GameObject bShield;
    public GameObject bLife;
    public Material[] materiais;
    public MeshRenderer meshMaterial;
    public Texture[] textures;
    int scoreChecks;
    public int life;
    public bool escudoActive;

    private UIManager _uiManager;
    private lazer _lazer;
    void Start()
    {
        life = 3;
        meshMaterial = GetComponent<MeshRenderer>();
        // meshMaterial.material.mainTexture = textures[0];
        _uiManager = FindObjectOfType(typeof(UIManager))as UIManager;
        _lazer =  FindObjectOfType(typeof(lazer)) as lazer;
        Time.timeScale =1f;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Rotate(new Vector3(0,0,1 * Time.deltaTime));
        if(life == 0)
        {
            meshMaterial.material = new Material(materiais[2]);
            _uiManager.AudioSetStop(1);
            _uiManager.AudioSet(0);
            _uiManager.SceneNext("Ranking");
            Time.timeScale = 0f;
           
        }
        if(life == 1)
        {

            meshMaterial.material = new Material(materiais[1]);
        }
        if(life == 2)
        {
            meshMaterial.material =  new Material(materiais[0]);
        }
        
        
        if(life == 3)
        {
            meshMaterial.material =  new Material(materiais[3]);
        }
        
        if(_uiManager.panelPause.gameObject.activeSelf == false && _lazer.cutting == false){ 
            if(_uiManager.score < 1000)
            
            {
                Time.timeScale = 1f;
                _uiManager.valueTimeScale = Time.timeScale;
            }

            if(_uiManager.score >= 1000 && _uiManager.score < 5000)
            {
                Time.timeScale = 1.2f;
                _uiManager.valueTimeScale = Time.timeScale;
            }
            if(_uiManager.score >= 5000 && _uiManager.score < 20000)
            {
                Time.timeScale = 1.4f;
                _uiManager.valueTimeScale = Time.timeScale;
            }
            if( _uiManager.score >= 20000 && _uiManager.score < 50000)
            {
                Time.timeScale = 1.6f;
                _uiManager.valueTimeScale = Time.timeScale;
            }if(_uiManager.score >= 50000 && _uiManager.score < 100000)
            {
                Time.timeScale = 1.8f;
                _uiManager.valueTimeScale = Time.timeScale;
            }
            
        }else if(_lazer.cutting == true)
        {
            Time.timeScale = 0.5f;
            StartCoroutine(Cutting(0.08f));
        }
        
    }


    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("asteroide"))
        {
            if(life > 0)
            {
                life -=1;
            }
            
        }
        if(other.gameObject.CompareTag("asteroide2"))
        {
            if(life <= 3 && life > 1 )
            {
                life -= 2;
            }
            else if( life == 1)
            {
                life -= 1;
            }
            
        }     
    }

    private void ChecksPontos()
    {
        
       
            Time.timeScale += 0.1f;

    }

    IEnumerator Cutting(float seconds){

        yield return  new WaitForSeconds(seconds);
        _lazer.cutting = false;
        Time.timeScale = _uiManager.valueTimeScale;
        
    }

    public void ActiveShield()
    {
        
        Instantiate(bShield, this.transform.position, Quaternion.identity);
        
    }
    public void ActiveLife()
    {
        
        Instantiate(bLife, this.transform.position, Quaternion.identity);
        life +=1;
        
        
    }

}
