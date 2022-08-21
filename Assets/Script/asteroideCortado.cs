using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroideCortado : MonoBehaviour
{
    public GameObject asteroide1;
    public GameObject asteroide2;
    void Start()
    {
        
    }

        void Update()
    {
        if( asteroide1 == null && asteroide2 == null)
        {
            Destroy(this.gameObject, 0.5f);
        }
    }
}
