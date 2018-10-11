using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerControll : NetworkBehaviour
{
    public float Speed;
    public int Leben;
    public GameObject Spawner;
    public float Energie;
    public float LebenAnzeige;
    public Image Leben_Image;
    public float EnergieAnzeige;
    public Image Energie_Image;
    public GameObject Neustart;
    public bool Mult2;
    public bool mult3;
    public bool Multiplayer = false;
    // Use this for initialization
    void Start () {
        Energie_Image = GameObject.Find("EngergieSlider").GetComponent<Image>();
        Leben_Image = GameObject.Find("LebenSlider").GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Multiplayer == true)
        {
            if (!isLocalPlayer)
                return;
       
        }
        if (Multiplayer == false )
        {

            if (Mult2 == false && mult3 == false)
            {
                LebenAnzeige = Leben;
                Leben_Image.fillAmount = LebenAnzeige / 100;
            }
            EnergieAnzeige = Energie;
            Energie_Image.fillAmount = EnergieAnzeige / 100;
        }
        if (Energie != 100)
        Energie += 0.3f;
        if (Input.GetKey(KeyCode.Space) && Energie > 1)
            {
            Energie -= 2;

        }
        if (Input.GetKey(KeyCode.Keypad0) && Energie > 1)
        {
            Energie -= 2;

        }

        if (Mult2 == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Rigidbody>().velocity += new Vector3(Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Rigidbody>().velocity -= new Vector3(Speed, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space) && Energie > 10)
            {

                Time.timeScale = 0.15f;
                Time.fixedDeltaTime = 0.02f * Time.deltaTime;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Time.timeScale = 1f;

            }
        }
        if(Mult2 == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody>().velocity += new Vector3(Speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody>().velocity -= new Vector3(Speed, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad0) && Energie > 10)
            {

                Time.timeScale = 0.15f;
                Time.fixedDeltaTime = 0.02f * Time.deltaTime;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Time.timeScale = 1f;

            }
        }
        if(Energie < 10)
        {
            Time.timeScale = 1f;
        }
            if (Leben <= 0 && mult3 == false)
        {
           
            if (Multiplayer == false)
            {
                Neustart.active = true;
                try
                {
                    Spawner.SendMessage("Save");
                }
                catch
                {

                }
                Destroy(Spawner);
            }

            if (Multiplayer == true)
            {
                Destroy(this.gameObject);
            }
            }
            if(Leben_Image.fillAmount <= 0)
        {
            if (Multiplayer == false)
            {
                Neustart.active = true;
                try
                {
                    Spawner.SendMessage("Save");
                }
                catch
                {

                }
                Destroy(Spawner);
            }

            if (Multiplayer == true)
            {
                Destroy(this.gameObject);
            }
        }
                }


    public void Dmg(int dmg)
    {
        if(Mult2 == false)
        Leben -= dmg;
        if(Mult2 == true)
        {
            Leben_Image.fillAmount = Leben_Image.fillAmount - 0.05f ;
        }
       if (mult3 == true)
        {
            Leben_Image.fillAmount = Leben_Image.fillAmount - 0.05f;
        }

    }
    //public override void OnStartLocalPlayer()
    //{
    //    GetComponent<MeshRenderer>().material.color = Color.blue;
    //}
    public void Mult()
    {
        Mult2 = true;

    }
}
