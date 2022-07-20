using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20 * Time.deltaTime, 0, 0));
    }


    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Planeta"))
        {
            Destroy(this.gameObject);

        }
    }

   
}
