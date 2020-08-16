﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //stats 
    public float Thp = 100;
    public float Chp = 100;
    public float speed = 10;
    public float AttackSpeed = 2;

    //shooting
    [SerializeField]
    bool Canshoot = true;
    public GameObject bullet;
    public GameObject camera;
    public GameObject hand;

    public CharecterControll CC;

    //game specific stuff


    public float coin = 0;
    public GameObject[] power;

    //shoot rocket
    public GameObject rocket;
    public float RocketChance;
    public GameObject RocketSpawn;

    // Start is called before the first frame update
    void Start()
    {
        CC=GetComponent<CharecterControll>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.transform.position, camera.transform.forward*1000,Color.green);
        Debug.DrawRay(hand.transform.position, hand.transform.forward * 1000, Color.green);

        shoot();

    }

    public void shoot()
    {
        if(Input.GetMouseButton(0)&& Canshoot)
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.point);

                hand.transform.forward = hit.point - transform.position;
                
                GameObject b = Instantiate(bullet, hand.transform.position + transform.forward, Quaternion.identity) as GameObject;
                b.transform.forward = hit.point - transform.position - new Vector3(0, 0.5f, 0) ;
                Rigidbody rb = b.GetComponent<Rigidbody>();
                rb.velocity = b.transform.forward * 50;
                Canshoot = false;
                Invoke("RCS", AttackSpeed );

                if(Random.Range(0,100)<RocketChance)
                {
                    Vector3 target = hit.point;
                    GameObject rockett = Instantiate(rocket, RocketSpawn.transform.position, RocketSpawn.transform.rotation);
                    rockett.GetComponent<rocketScript>().target = target;
                }

            }
        }
    }

    void UpdateHp()
    {
        Thp += 10;
        if(Chp== Thp-10)
        {
            Chp = Thp;
        }
    }
    void UpdateSpeed()
    {
        speed += 3;
        CC.speed += speed;
    }
    void UpdateAttackSpeed()
    {
        AttackSpeed -= 0.2f;
    }
    void UpdateRocketChance()
    {
        RocketChance +=1;
    }


    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Hp")
        {
            UpdateHp();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Speed")
        {
            UpdateSpeed();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "AttackSpeed")
        {
            UpdateAttackSpeed();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "RC")
        {
            UpdateRocketChance();
            Destroy(collision.gameObject);
        }
    }
    public void RCS()
    {
        Canshoot = true;
    }
}
