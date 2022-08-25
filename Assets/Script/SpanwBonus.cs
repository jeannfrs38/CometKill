using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwBonus: MonoBehaviour
{

    private UIManager _uiManager;
    private Planeta _planeta;
    public  float  intervalo;
    public float  ultimoIntervalo;
    public  float  intervalo2;
    public float  ultimoIntervalo2;
    public bool  valorAleatorioIntervalo;
    public bool  valorAleatorioIntervalo2;

    
    [SerializeField] public float yMax;
    [SerializeField] public float yMin;


    public List<GameObject> bonus = new List<GameObject>();
    
   

    private void Start() {
        _uiManager = FindObjectOfType(typeof(UIManager)) as UIManager;
        _planeta =  FindObjectOfType(typeof(Planeta)) as Planeta;
        intervalo = RandomNumber(30, 240);
        intervalo2 = RandomNumber(30, 240);
        ultimoIntervalo = Time.time;
        ultimoIntervalo2 = Time.time;
    }
    void Update()
    {

        if(_uiManager.buttonLife.activeSelf == false)
            {
               
           
                SpawnerBonusLife();
                
                
            }        
        if(_uiManager.buttonShield.activeSelf == false && _uiManager.score > 5000)
            {
                
                SpawnerBonusShield();
                 
                
            }
            
       
            
        
      
        
     
        
    }


    public void SpawnerBonusShield()
    {
                
       
        if(Time.time >= intervalo + ultimoIntervalo)
        {
            float YMove = Random.Range(yMin, yMax);
            
            Vector3 posisao = new Vector3(transform.position.x, YMove, transform.position.z);
            Debug.Log(YMove);
            
            Instantiate(bonus[0], posisao, Quaternion.identity);
             ultimoIntervalo = Time.time;
             
            

        }
        
    }
    public void SpawnerBonusLife()
    {
        
        if(Time.time >= intervalo2 + ultimoIntervalo2)
        {
            float YMove = Random.Range(yMin, yMax);
            
            Vector3 posisao = new Vector3(transform.position.x, YMove, transform.position.z);
            Debug.Log(YMove);
            ultimoIntervalo2 = Time.time;
            Instantiate(bonus[1], posisao, Quaternion.identity);
            
            
            
        }
        
    }
    public int RandomNumber(int indexStart, int indexFinish)
    {
        int randomInt ;
        return randomInt = Random.Range(indexStart, indexFinish);
            
    }
    

    
}
