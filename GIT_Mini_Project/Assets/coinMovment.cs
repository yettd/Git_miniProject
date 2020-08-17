using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMovment : MonoBehaviour
{
    GameObject player;
    public float speed;
    Rigidbody rb;

    bool turn = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!turn)
        {
            transform.forward = Vector3.Lerp(transform.forward,
    
            player.transform.position - transform.position,Time.deltaTime);
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            StartCoroutine(turning());
        }
        else
        {
            transform.forward = Vector3.Lerp(transform.forward,

          player.transform.position - transform.position,1);
            rb.MovePosition(transform.position + transform.forward * speed*10 * Time.deltaTime);
        }

        

    }

       public IEnumerator turning()
    {
        yield return new WaitForSeconds(2);
        turn = true;
    }
}
