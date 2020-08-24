using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketScript : MonoBehaviour
{

    public Vector3 target;
    Rigidbody rb;
    public float speed;
    public GameObject expl;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.Lerp(transform.forward,
            target - transform.position, Time.deltaTime);
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(expl,transform.position,Quaternion.identity);
   
        Destroy(gameObject);
    }
}
