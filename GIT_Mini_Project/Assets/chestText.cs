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
<<<<<<< HEAD
        TM.text = c.AmountToOpen +"TO OPEN CHEST PRESS F";
=======
        TM.text = c.AmountToOpen + "TO OPEN CHEST PRESS F";
>>>>>>> 20_pohJunKai_v2
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        transform.forward = transform.position- player.transform.position;
=======
        transform.forward = transform.position - player.transform.position;
>>>>>>> 20_pohJunKai_v2
    }
}
