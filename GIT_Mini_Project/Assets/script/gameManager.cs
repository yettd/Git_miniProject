using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager ins;
    public GameObject spawner;
    // Start is called before the first frame update
    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        InvokeRepeating("spawn", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spawn()
    {
        GameObject a = Instantiate(spawner, transform.position + Random.insideUnitSphere * 50, Quaternion.identity) as GameObject;
        a.transform.position = new Vector3(a.transform.position.x, transform.position.y, a.transform.position.z);
    }
    public void changeAtimer()
    {
        CancelInvoke("spawn");
        InvokeRepeating("spawn", 0, 1);

    }
}
