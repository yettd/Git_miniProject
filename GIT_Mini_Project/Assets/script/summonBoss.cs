using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonBoss : MonoBehaviour
{

    //wrong name but this is for the teleporter charging up


    Renderer r;

    public Material fullycharge;

    [SerializeField]
    public float charging = 0;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charging>=100)
        {
            gameObject.tag = "fullyChargeTele";
            r.material = fullycharge;
        }
        else
        {
            charging += Time.deltaTime * 5;
        }
    }
    
}
