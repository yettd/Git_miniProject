using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceText : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = transform.position - player.transform.position;

    }
}
