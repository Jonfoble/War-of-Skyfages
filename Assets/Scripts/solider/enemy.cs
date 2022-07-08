using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject nearEnemy;
    public float hitDistace;
    public float hiz;
    public bool enemyHere = false;
    public int myIndex;
    public GameObject ondeki;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public int earning;
    public int health = 100;
    public int hasar;
    public int hasarBase;
    bool inBase;
    int triggers = 0;
    bool triggerStay;
    Vector3 cehennem = new Vector3(0, 100, 100);
    int Esira = 0;
    string ondekiName;

    Vector3 spawnPosition;
    public float yogunlukMy;
    int guc;
    int guc2;
    int guc3;
    bool oldu;

    public Animator anim;
    void Start()
    {

        spawnPosition = transform.position;
        if (gameObject.transform.position == GameObject.Find("Cylinder5").transform.position)
        {
            myIndex = GameObject.Find("spawner").GetComponent<index>().enemyno1;
            gameObject.name = "1enemy" + myIndex.ToString();
            Esira = 1;
            this.gameObject.transform.GetChild(1).tag = "Esira1";
        }
        if (gameObject.transform.position == GameObject.Find("Cylinder6").transform.position)
        {
            myIndex = GameObject.Find("spawner").GetComponent<index>().enemyno2;
            gameObject.name = "2enemy" + myIndex.ToString();
            Esira= 2;
            this.gameObject.transform.GetChild(1).tag = "Esira2";
        }
        if (gameObject.transform.position == GameObject.Find("Cylinder7").transform.position)
        {
            myIndex = GameObject.Find("spawner").GetComponent<index>().enemyno3;
            gameObject.name = "3enemy" + myIndex.ToString();
            Esira = 3;
            this.gameObject.transform.GetChild(1).tag = "Esira3";
        }
        if (gameObject.transform.position == GameObject.Find("Cylinder8").transform.position)
        {
            myIndex = GameObject.Find("spawner").GetComponent<index>().enemyno4;
            gameObject.name = "4enemy" + myIndex.ToString();
            Esira = 4;
            this.gameObject.transform.GetChild(1).tag = "Esira4";
        }
        if (gameObject.transform.position == GameObject.Find("Cylinder9").transform.position)
        {
            myIndex = GameObject.Find("spawner").GetComponent<index>().enemyno5;
            gameObject.name = "5enemy" + myIndex.ToString();
            Esira = 5;
            this.gameObject.transform.GetChild(1).tag = "Esira5";
        }
        if (gameObject.tag == "tahtaliE")
        {
            guc = 20;

        }
        if (gameObject.tag == "mizrakciE")
        {
            guc = 30;
        }
        if (gameObject.tag == "kilicliE")
        {
            guc = 35;
        }

    }
	private void FixedUpdate()
	{
        int ageLevelE = GameObject.Find("spawner").GetComponent<level>().levelNowE;
        if (ageLevelE == 2)
        {
            guc2 = guc * ageLevelE;
            earning = 16;
        }
        else if (ageLevelE == 3)
        {
            guc3 = guc * ageLevelE;
            earning = 30;
        }
        yogunlukMy = guc;

        if (triggers == 0)
        {
            triggerStay = false;
        }
        if (triggerStay == false)
        {
            nearEnemy = null;
            enemyHere = false;
            inBase = false;
        }
        if (inBase == true)
        {
            baseAttac();
        }
        if (nearEnemy != null)
        {
            Attac();
        }
        if (health <= 0)
        {
            // bekleme yap
            anim.SetInteger("komut", 4);
            transform.position = cehennem;
            if (oldu == false)
            {
                oldu = true;
                if (GameObject.Find("spawner").GetComponent<level>().levelNow == 1)
                {
                    GameObject.Find("spawner").GetComponent<level>().xp += guc;
                }
                else if (
                    GameObject.Find("spawner").GetComponent<level>().levelNow == 2)
                {
                    GameObject.Find("spawner").GetComponent<level>().xp += guc2;
                }
                else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 3)
                {
                    GameObject.Find("spawner").GetComponent<level>().xp += guc3;
                }
                GameObject.Find("spawner").GetComponent<spawner>().para += earning;

                
            }
            Destroy(gameObject, 0.2f);
        }
        if (Esira == 1)
        {
            ondeki = GameObject.Find("1enemy" + (myIndex - 1).ToString());
            ondekiName = "1enemy" + (myIndex - 1).ToString();
        }
        if (Esira == 2)
        {
            ondeki = GameObject.Find("2enemy" + (myIndex - 1).ToString());
            ondekiName = "2enemy" + (myIndex - 1).ToString();
        }
        if (Esira == 3)
        {
            ondeki = GameObject.Find("3enemy" + (myIndex - 1).ToString());
            ondekiName = "3enemy" + (myIndex - 1).ToString();
        }
        if (Esira == 4)
        {
            ondeki = GameObject.Find("4enemy" + (myIndex - 1).ToString());
            ondekiName = "4enemy" + (myIndex - 1).ToString();
        }
        if (Esira == 5)
        {
            ondeki = GameObject.Find("5enemy" + (myIndex - 1).ToString());
            ondekiName = "5enemy" + (myIndex - 1).ToString();
        }

        if (GameObject.Find(ondekiName) != null)
        {
            if (ondeki.transform.position.x - gameObject.transform.position.x > 3 && inBase == false)
            {
                rb.velocity = transform.forward * hiz;
                anim.SetInteger("komut", 2);
            }
            else
            {
                rb.velocity = transform.forward * 0;
                anim.SetInteger("komut", 1);
            }

        }
        else
        {
            if (enemyHere == false && inBase == false)
            {
                rb.velocity = transform.forward * hiz;
                anim.SetInteger("komut", 2);
            }
            else
            {
                rb.velocity = transform.forward * 0;
                if (inBase == true) { anim.SetInteger("komut", 3); }
            }
        }
    
}
	private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "allied")
        {
            nearEnemy = other.gameObject;
            enemyHere = true;
        }
        else if (other.gameObject.tag == "ally base")
        {
            inBase = true;
        }
        triggerStay = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        triggers++;
    }
    private void OnTriggerExit(Collider other)
    {
        triggers--;
        if (other.gameObject.tag == "allied")
        {
            enemyHere = false;
        }
    }








    void Attac()
    {
        anim.SetInteger("komut", 3);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            nearEnemy.transform.parent.GetComponent<solider>().health = nearEnemy.transform.parent.GetComponent<solider>().health - hasar;
        }
    }
    void baseAttac()
    {
        anim.SetInteger("komut", 3);
        if (Time.time > nextFire)
        {
            rb.velocity = transform.forward * 0;
            nextFire = Time.time + fireRate;
            GameObject.Find("spawner").GetComponent<index>().allyBase = GameObject.Find("spawner").GetComponent<index>().allyBase - hasarBase;
        }
    }
}
    