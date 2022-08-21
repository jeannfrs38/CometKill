using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanw : MonoBehaviour
{
    public  float  intervalo;
    public float  ultimoIntervalo;
    public  float  intervalo2;
    public float  ultimoIntervalo2;
    public float contador;

    [SerializeField] public float xMax;
    [SerializeField] public float xMin;
    [SerializeField] public float yMax;
    [SerializeField] public float yMin;


    public GameObject asteroides;
    public GameObject asteroides2;
    void Start()
    {
        
    }

    
    void Update()
    {



        SpawnerAsteroid();
        SpawnerAsteroidMaior();
        
    }


    public void SpawnerAsteroid()
    {
        if(Time.time > intervalo + ultimoIntervalo)
        {
            float XMove = Random.Range(xMin, xMax);
            Vector3 posisao = new Vector3(XMove, transform.position.y, transform.position.z);
            ultimoIntervalo = Time.time;
            Instantiate(asteroides, posisao, Quaternion.identity);
            contador =0;

        }
    }
    public void SpawnerAsteroidMaior()
    {
        if(Time.time > intervalo2 + ultimoIntervalo2)
        {
            float XMove = Random.Range(xMin, xMax);
            Vector3 posisao = new Vector3(XMove, transform.position.y, transform.position.z);
            ultimoIntervalo2 = Time.time;
            Instantiate(asteroides2, posisao, Quaternion.identity);
            contador =0;

        }
    }

    
}
