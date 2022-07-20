using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputs : MonoBehaviour
{
    

    public Vector3 positionTouch;
     RaycastHit hit;
    void Update()
    {
       if(Input.touchCount > 0){
           Touch touch = Input.GetTouch(0);
            
           
            
        }
    }
    void FixedUpdate()
    {
        
    }
}
