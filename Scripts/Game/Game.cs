using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    public bool Multi;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.R) && Multi == true)
        {
            Application.LoadLevel("2");
        }
        if (Input.GetKeyDown(KeyCode.R)&& Multi == false)
        {
            Application.LoadLevel("1");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
        }
    }
}
