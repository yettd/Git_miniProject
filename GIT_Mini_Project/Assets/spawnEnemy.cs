using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{

    public GameObject[] enemy;

    public float timer ;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(1, 10);
        print(timer);
        Invoke("flight", timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flight()
    {
        print("air");
        Instantiate(enemy[1],transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("ground");
        CancelInvoke("flight");
        Instantiate(enemy[0], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
