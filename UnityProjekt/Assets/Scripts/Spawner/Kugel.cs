using UnityEngine;
using System.Collections;

public class Kugel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boden")
        {
            StartCoroutine(Despawn());
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Dmg", 25);
            Destroy(this.gameObject);
        }

    }



    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
    }
