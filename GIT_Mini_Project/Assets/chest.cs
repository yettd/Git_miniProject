using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{

    public GameObject[] power;

    public float coin = 0;

    playerScript PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = transform.parent.gameObject.GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
     
    }
    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "chest" && Input.GetKeyDown(KeyCode.F))
        {
            if (collision.gameObject.GetComponent<chestPrice>().AmountToOpen < coin)
            {
                float amount = collision.gameObject.GetComponent<chestPrice>().AmountToOpen;
                coin -= amount;
                Instantiate(power[Random.Range(0, power.Length)], collision.gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "chest")
        {
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "chest")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="coin")
        {
            print("Get Coin");

            coin++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "enemy")
        {
            PS.Chp -= other.gameObject.GetComponent<enemy>().damage;
        }
        else if (other.gameObject.tag == "enemybullet")
        {
            PS.Chp -= other.gameObject.GetComponent<bullet>().damage;
        }
    }

}
