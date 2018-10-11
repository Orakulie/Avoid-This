using UnityEngine;
using System.Collections;

public class Starten : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Starte()
    {
        Application.LoadLevel("1");
    }
    public void Beenden()
    {
        Application.Quit();
    }
    public void Multiplayer()
    {
        Application.LoadLevel(2);
    }
}
