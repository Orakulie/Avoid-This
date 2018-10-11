using UnityEngine;
using System.Collections;


public class Spawn : MonoBehaviour
{
    public bool Multi;
    public GameObject Obj;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


   
    public void SpawnObj()
    {
        
        Instantiate(Obj, transform.position, transform.rotation);
   
    }
}
