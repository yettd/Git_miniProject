using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    //stats 
    public float Thp = 100;
    public float Chp = 100;
    public float speed = 10;
    public float AttackSpeed = 2;
    public Text powerup;
   

    //shooting
    [SerializeField]
    bool Canshoot = true;
    public GameObject bullet;
    public GameObject camera;
    public GameObject hand;

    public CharecterControll CC;

    public GameObject boss;

    //game specific stuff


    public float coin = 0;
    public GameObject[] power;
        
    //shoot rocket
    public GameObject rocket;
    public float RocketChance;
    public GameObject RocketSpawn;

    //regain health
    bool regain = false;

    // Start is called before the first frame update
    void Start()
    {
       
        CC =GetComponent<CharecterControll>();
        powerup.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.DrawRay(camera.transform.position, camera.transform.forward*1000,Color.green);
        Debug.DrawRay(hand.transform.position, hand.transform.forward * 1000, Color.green);
        shoot();
        if (transform.position.y <= -20)
        {
            StartCoroutine(ShowMessage("Press R to Restart.", 2));
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
           
        }
        if(Chp<Thp )
        {
            if(regain==false)
            {
                Invoke("activateRegain", 2);
            }
        }
    }

    public void activateRegain()
    {
        regain = true;

        InvokeRepeating("healthRegain", 0, 0.1f);

        CancelInvoke("activateRegain");
    }

    public void healthRegain()
    {
        Chp += 1;
        if(Chp>Thp)
        {
            Chp = Thp;
            regain = false;
            CancelInvoke("healthRegain");
        }
    }
    public void cancelHp()
    {
        regain = false;
        CancelInvoke("healthRegain");
    }

    public void shoot()
    {
        if(Input.GetMouseButton(0)&& Canshoot)
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

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
            StartCoroutine(ShowMessage("health Increase!", 2));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Speed")
        {
            UpdateSpeed();
            StartCoroutine(ShowMessage("Speed Increase!", 2));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "AttackSpeed")
        {
            UpdateAttackSpeed();
            StartCoroutine(ShowMessage("Attack Speed Increase!", 2));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "RC")
        {
            UpdateRocketChance();
            StartCoroutine(ShowMessage("Rocket Chance Increase!", 2));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "enemy")
        {
            Chp -= 10;
           
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "tele" && Input.GetKeyDown(KeyCode.F))
        {
            gameManager.ins.changeAtimer();
            other.gameObject.GetComponent<summonBoss>().enabled = true;
            other.gameObject.tag = "Untagged";
        }
        if (other.gameObject.tag == "fullyChargeTele" && Input.GetKeyDown(KeyCode.F))
        {
            print("done");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        powerup.text = message;
        powerup.enabled = true;
        yield return new WaitForSeconds(delay);
        powerup.enabled = false;
    }
    public void RCS()
    {
        Canshoot = true;
    }
}
