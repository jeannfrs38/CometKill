using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planeta : MonoBehaviour
{
    public Material[] materiais;
    public MeshRenderer meshMaterial;
    public Texture[] textures;

    public int life;

    private UIManager _uiManager;
    void Start()
    {
        life = 3;
        meshMaterial = GetComponent<MeshRenderer>();
        // meshMaterial.material.mainTexture = textures[0];
        _uiManager = FindObjectOfType(typeof(UIManager))as UIManager;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1 * Time.deltaTime));

        if(life == 2)
        {
            meshMaterial.material =  new Material(materiais[0]);
        }
        if(life == 1)
        {
            meshMaterial.material = new Material(materiais[1]);
        }
        if(life == 0)
        {
            meshMaterial.material = new Material(materiais[2]);
            _uiManager.SceneNext("Ranking");
           
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
            if(life > 0)
            {
                life -=1;
            }
            
        }     
    }
}
