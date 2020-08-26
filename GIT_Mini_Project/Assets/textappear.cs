using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textappear : MonoBehaviour
{
    
    TextMesh TM;
    GameObject player;
    summonBoss boss;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TextMesh>();
        TM.text = "Press F to charge teleopoter";
        player = GameObject.FindGameObjectWithTag("Player");
        boss = transform.parent.gameObject.GetComponent<summonBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = transform.position - player.transform.position;
        if (boss.enabled == true)
        {
            TM.text = boss.charging.ToString("#")+"%";
            if (transform.parent.gameObject.tag == "fullyChargeTele")
            {
                TM.text = "Fully Charged.";
            }
        }
    }
}
