using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Spawner : NetworkBehaviour
{
  
  
    public int Rand;
    public Transform SpawnerChild;
    public Text Stufe_Text;
    public Text HS_Text;
    public GameObject Kugel;
    public bool Mult;
    public GameObject Player;
    [SyncVar]
    public int Level;
    public float Stufe;

    // Use this for initialization
    void Start () {
        HS_Text.text = "Highscore: " + PlayerPrefs.GetInt("Stufe");
        StartCoroutine(Frequenz());
        if (Mult == true)
        {
            GameObject play = Instantiate(Player,new Vector3(0,0,0),Quaternion.identity);
            play.SendMessage("Mult");
        }
    }

    // Update is called once per frame
    
    void Update () {
        
    Stufe_Text.text = "" + Level;
        if(Stufe >= 30)
        {
            Stufe = 5;
        }

    }




    public void RandomSpawner()
    {
        Rand = Random.Range(0, 7);
       
    }

    IEnumerator Frequenz()
    {
        Level += 1;
        Stufe += 0.5f;
        yield return new WaitForSeconds(3/Stufe);
        Spawnen();
    }

    public void Spawnen()
    {
        RandomSpawner();
        SpawnerChild = this.gameObject.transform.GetChild(Rand);
        
        var enemy = (GameObject)Instantiate(Kugel, SpawnerChild.transform.position, SpawnerChild.transform.rotation);
    
        
        //try
        //{
        //    NetworkServer.Spawn(enemy);
        //}catch
        //{

        //}
       
        
        StartCoroutine(Frequenz());
    }
    public void Save()
    {
        if (Level > PlayerPrefs.GetInt("Stufe"))
            {
            PlayerPrefs.SetInt("Stufe", Level);
        }
    }
}
