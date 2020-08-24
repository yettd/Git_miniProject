using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestText : MonoBehaviour
{
    public chestPrice c;
    TextMesh TM;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TextMesh>();
        TM.text = c.AmountToOpen + "TO OPEN CHEST PRESS F";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = transform.position - player.transform.position;
    }
}
