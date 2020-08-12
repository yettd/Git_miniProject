using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMadeCamera : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float rotX;
    private float rotY;
    public float mouseX;
    public float mouseY;
    private float finX;
    private float finY;
    private float maxY=80;
    public float sens;
    public float CameraMoveSpeed=150;

    //target
    public GameObject target;
    public bool lockOn;
    private GameObject getTarget;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rotX = rot.x;
        rotY = rot.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
            mouseX = Input.GetAxis("Mouse X");

            mouseY = Input.GetAxis("Mouse Y");
            rotX += mouseX * sens * Time.deltaTime;

            rotY += -mouseY * sens * Time.deltaTime;
            Quaternion localRotaion = Quaternion.Euler(rotY, rotX, 0.0f);
            rotY = Mathf.Clamp(rotY, -maxY, maxY);
            transform.rotation = localRotaion;
            player.transform.Rotate(Vector3.up * mouseX * sens * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.F))
            {
                lockOn = true;
                getTarget = null;
            }

        
      
    }
    private void LateUpdate()
    {
        CameraUpdater();
    }
     private void CameraUpdater()
    {
        Transform target = player.transform;

        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.position.x,target.position.y+1,target.position.z), step);
    }

   
}
