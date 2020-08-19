using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    GameObject player;
    public float hp;
    public float speed;
    public float damage;
    Rigidbody rb;
    public GameObject coin;

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.Lerp(transform.forward,
            player.transform.position - transform.position, Time.deltaTime);
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

        if(hp<=0)
        {
            for (int i = 0; i < Random.Range(5,10); i++)
            {
                Instantiate(coin, transform.position, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)));
            }
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="bullet")
        {
            hp-= collision.gameObject.GetComponent<bullet>().damage;
            GameObject a = Instantiate(text, transform.position, Quaternion.identity);
            a.GetComponent<TextMesh>().text= collision.gameObject.GetComponent<bullet>().damage.ToString();
            a.GetComponent<Rigidbody>().velocity += new Vector3(0, 10, 0);
            Destroy(a, 1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "explo")
        {
            hp -= other.gameObject.GetComponent<explosion>().damage;
            GameObject a = Instantiate(text, transform.position, Quaternion.identity);
            a.GetComponent<TextMesh>().text = other.gameObject.GetComponent<bullet>().damage.ToString();
            a.GetComponent<Rigidbody>().velocity += new Vector3(0, 10, 0);
            Destroy(a, 1);
        }
    }
}
