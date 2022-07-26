﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{

     public GameObject lazerTrailPrefab;
     public GameObject explosion;
     public float minCuttingVelocity = 1f;
     GameObject currentLazerTrail;
     public bool isCutting = false;
     public bool cutting = false;
      Rigidbody2D rb;
      Camera cam;
      public Vector2 positionTouch;
      public Vector2 positionTouch2;
      public Vector2 previousPosition;
      public Vector2 newPosition;

      CircleCollider2D circleCollider;

      RaycastHit hit;
      RaycastHit hit2;

      Touch touch;

      LazerTrail _lazerTrail;

      UIManager _uiManager;

      
      public GameObject asteroideM;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
        _lazerTrail = FindObjectOfType(typeof(LazerTrail)) as LazerTrail;
        _uiManager = FindObjectOfType(typeof(UIManager)) as UIManager;
    }

    // Update is called once per frame
    void Update()
    {
         
       if(Input.touchCount > 0){
           touch = Input.GetTouch(0);
            
            
            
            
            if(touch.phase == TouchPhase.Began)
            {
                
                positionTouch = cam.ScreenToWorldPoint(touch.position);
                
               
                
                int layerMask = 1 << 11;
                int layerMask1 = 1 << 14;
                int layerMask3 = 1 << 15;
                
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        AudioManager.audioManagerInstace.PlayAudioOne(3);
                        Destroy(hit.transform.gameObject);
                        _uiManager.AddScore(100);
                        Instantiate(explosion, hit.transform.position, Quaternion.identity);
                        StartCoroutine(Explosion(0.8f));

                    
                    print("Hit something!");
                
                    } 
                     if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask1))
                    {
                        AudioManager.audioManagerInstace.PlayAudioOne(3);
                        Destroy(hit.transform.gameObject);
                        
                        Instantiate(explosion, hit.transform.position, Quaternion.identity);
                        StartCoroutine(Explosion(0.8f));
                        _uiManager.ButtonBonusLife();
                        AudioManager.audioManagerInstace.StopEffect(8);
                      
                   
                    
                    
                
                    }if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask3))
                    {
                        AudioManager.audioManagerInstace.PlayAudioOne(3);
                        Destroy(hit.transform.gameObject);
                        
                        Instantiate(explosion, hit.transform.position, Quaternion.identity);
                        StartCoroutine(Explosion(0.8f));
                        _uiManager.ButtonBonusShield();
                        AudioManager.audioManagerInstace.StopEffect(8);

                    } 
                
               
                
            }
           
            
            else if(touch.phase ==  TouchPhase.Moved)
            {
                StartCutting();
                positionTouch = cam.ScreenToWorldPoint(touch.position);
               
                int layerMask2 = 1 << 12;
                
                    Ray ray2 = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray2, out hit2, Mathf.Infinity, layerMask2))
                    {
                        Instantiate(asteroideM, hit2.transform.position, hit2.transform.rotation);

                        Destroy(hit2.transform.gameObject);
                        cutting = true;
                        _uiManager.AddScore(200);
                        AudioManager.audioManagerInstace.StopEffect(3);
                        AudioManager.audioManagerInstace.PlayAudioOne(4);
                        Instantiate(explosion, hit2.transform.position, Quaternion.identity);
                         StartCoroutine(Explosion(0.8f));
                        Time.timeScale = 0.5f;
                        
                
                
                    } 
                    
                    StartCoroutine(TrailEmission(0.09f));
                    
                    
                
                
                

                
            }
             if(touch.phase == TouchPhase.Ended)
            {
                StopCutting();
                
            }
            
            
            
        } 
        if(isCutting)
            {
                UpdateCut();
                
            }
        

        
       
        
    }  
    


    void UpdateCut()
    {
        newPosition = positionTouch;
        rb.position = newPosition;
       
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity )
        {
           
            circleCollider.enabled = true;
            // currentLazerTrail = Instantiate(lazerTrailPrefab, transform);
            
            
            
        }else
        {
            circleCollider.enabled =  false;
             
            
        }
        previousPosition = newPosition;
    }
    void StartCutting()
    {
        isCutting = true;
         _lazerTrail.ChangeTrailState(false, 0f);
        
        previousPosition =  cam.ScreenToWorldPoint(touch.position);
            
        circleCollider.enabled = false;

    }
    void StopCutting()
    {
        isCutting = false;
        if(currentLazerTrail != null)
        {
            currentLazerTrail.transform.SetParent(null);
            Destroy(currentLazerTrail, 0.2f);
        }
       
        circleCollider.enabled = false;
    }
    IEnumerator TrailEmission(float seconds){

        yield return  new WaitForSeconds(seconds);
        _lazerTrail.ChangeTrailState(true, 0.2f);
        
        
    }

    IEnumerator Explosion(float seconds){

        yield return  new WaitForSeconds(seconds);
        AudioManager.audioManagerInstace.PlayAudioOne(5);
        
        
    }

  
   

}
