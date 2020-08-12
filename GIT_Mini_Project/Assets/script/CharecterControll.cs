using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CharecterControll : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController CC;
    //movement
    float h;
    float v;

    public float speed;
    public Transform orientation;
    private float walk;
    Vector3 moveDirention;
    private float grav = 13;
    public GameObject camera;
    private float vertcalvelo;
    public AudioClip[] AC;

    void Awake()
    {
        CC = GetComponent<CharacterController>();
    }

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void FixedUpdate()
    {
    }

    private void Update()
    {
        Movement();
        sprint();
        MyInput();
        jump();

    }


    private void MyInput()
    {
        //walking
        if (Input.GetKeyDown(KeyCode.W))
        {
            walk++;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            walk--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            walk--;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            walk++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            walk += 3;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            walk -= 3;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            walk -= 3;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            walk += 3;
        }

        //jump
    }

    private void Movement()
    {
     
            switch (walk)
            {
                case 1:
                    moveDirention = new Vector3(0, 0, 1);
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                    moveDirention *= speed;
                    moveDirention = orientation.transform.TransformDirection(moveDirention);
                    break;
                case 0:
                    moveDirention = new Vector3(0, 0, 0);
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

                    break;
                case -1:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                case 2:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y - 45 + 180, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                case -2:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y - 45, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                case -3:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                case 3:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                case -4:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y + 45 + 180, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                case 4:
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y + 45, transform.rotation.eulerAngles.z);
                    moveDirention = orientation.transform.forward * speed;
                    break;
                default:
                    moveDirention = new Vector3(0, 0, 0);
                    orientation.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                    break;
            }
        
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, camera.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);


        moveDirention.y -= grav * Time.deltaTime;
        CC.Move(moveDirention * Time.deltaTime);
    }
    public void jump()
    {
        if (CC.isGrounded)
        {
            vertcalvelo = -grav * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                    vertcalvelo = 10;
                

            }
        }
        else
        {
            vertcalvelo -= grav * Time.deltaTime;

        }
            Vector3 movevector = new Vector3(0, vertcalvelo, 0);
            CC.Move(movevector * Time.deltaTime);
     

    }


    public void sprint()
    {
        
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 20;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 10;

            }
       

    }
    

}