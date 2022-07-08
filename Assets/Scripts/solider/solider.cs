using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solider : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject nearEnemy;
    public float hitDistace;
    public float hiz;
    public bool enemyHere = false;
    public int myIndex;
    public GameObject ondeki;
    public float fireRate = 1f;
    private float nextFire = 0.0f;
    public int earning;
    public int health = 50;
    public int hasar;
    public int hasarBase;
    bool inBase;
    int triggers = 0;
    bool triggerStay;
    Vector3 cehennem = new Vector3(0,100,100);
    int sira = 1;
    string ondekiName;

    public float yogunlukMy;
    int guc;
    int guc2;
    int guc3;
    Vector3 spawnPosition;
    bool oldu;

    public Animator anim;


	void Start()
    {
        spawnPosition = transform.position;
        if(gameObject.transform.position == GameObject.Find("Cylinder").transform.position){
        myIndex = GameObject.Find("spawner").GetComponent<index>().indexno1;
        gameObject.name = "1solider" + myIndex.ToString();
        sira = 1;
        this.gameObject.transform.GetChild(1).tag = "sira1";
        }
        if(gameObject.transform.position == GameObject.Find("Cylinder1").transform.position){
        myIndex = GameObject.Find("spawner").GetComponent<index>().indexno2;
        gameObject.name = "2solider" + myIndex.ToString();
        sira = 2;
        this.gameObject.transform.GetChild(1).tag = "sira2";
        }
        if(gameObject.transform.position == GameObject.Find("Cylinder2").transform.position){
        myIndex = GameObject.Find("spawner").GetComponent<index>().indexno3;
        gameObject.name = "3solider" + myIndex.ToString();
        sira = 3;
        this.gameObject.transform.GetChild(1).tag = "sira3";
        }
        if(gameObject.transform.position == GameObject.Find("Cylinder3").transform.position){
        myIndex = GameObject.Find("spawner").GetComponent<index>().indexno4;
        gameObject.name = "4solider" + myIndex.ToString();
        sira = 4;
        this.gameObject.transform.GetChild(1).tag = "sira4";
        }
        if(gameObject.transform.position == GameObject.Find("Cylinder4").transform.position){
        myIndex = GameObject.Find("spawner").GetComponent<index>().indexno5;
        gameObject.name = "5solider" + myIndex.ToString();
        sira = 5;
        this.gameObject.transform.GetChild(1).tag = "sira5";
        }
        if(gameObject.tag == "tahtali"){
            guc = 20;
        }
        if(gameObject.tag == "mizrakci"){
            guc = 25;
        }
        if (gameObject.tag == "kilicli")
        {
            guc = 30;
        }
    }

    void FixedUpdate(){
        int ageLevel = GameObject.Find("spawner").GetComponent<level>().levelNow;
        if (ageLevel == 2)
        {
            guc2 = guc * ageLevel;
            guc = guc2;
            earning = 16;
        }
		else if (ageLevel == 3)
		{
            guc3 = guc * ageLevel;
            guc = guc3;
            earning = 40;
		}
            yogunlukMy = guc * (spawnPosition.x - transform.position.x);
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
                GameObject.Find("spawner").GetComponent<spawner>().paraE += earning;
                }
                Destroy(gameObject, 0.2f);
            }
    if(sira == 1){
    ondeki = GameObject.Find("1solider" + (myIndex-1).ToString());
    ondekiName = "1solider" + (myIndex-1).ToString();
    }
    if(sira == 2){
    ondeki = GameObject.Find("2solider" + (myIndex-1).ToString());
    ondekiName = "2solider" + (myIndex-1).ToString();
    }
    if(sira == 3){
    ondeki = GameObject.Find("3solider" + (myIndex-1).ToString());
    ondekiName = "3solider" + (myIndex-1).ToString();
    }
    if(sira == 4){
    ondeki = GameObject.Find("4solider" + (myIndex-1).ToString());
    ondekiName = "4solider" + (myIndex-1).ToString();
    }
    if(sira == 5){
    ondeki = GameObject.Find("5solider" + (myIndex-1).ToString());
    ondekiName = "5solider" + (myIndex-1).ToString();
    }

    if(GameObject.Find(ondekiName) != null){
        if(gameObject.transform.position.x-ondeki.transform.position.x > 3 && inBase == false)
        {
            rb.velocity = transform.forward * hiz;    
            anim.SetInteger("komut",2);
        }
        else
        {
            rb.velocity = transform.forward * 0;
            anim.SetInteger("komut",1);
        }
    }
    else
    {
        if(enemyHere == false && inBase == false){
            rb.velocity = transform.forward * hiz;
            anim.SetInteger("komut",2);
        }
        else{
            rb.velocity = transform.forward * 0;
            if(inBase == true){anim.SetInteger("komut",3);}
        }
    }


        // base saldirisini enemy yoksa yap
    }
private void OnTriggerStay(Collider other) {
     if(other.gameObject.tag =="enemy")
    {
        nearEnemy = other.gameObject;
        enemyHere = true;
    }
    else if(other.gameObject.tag == "enemy base"){
        inBase = true;
    }
    triggerStay = true;
}
private void OnTriggerEnter(Collider other) {
    triggers++;
}
private void OnTriggerExit(Collider other) {
    triggers--;
    if(other.gameObject.tag == "enemy")
    {
        enemyHere = false;
    }
}
void Attac(){
    anim.SetInteger("komut",3);
if (Time.time > nextFire)
{
    nextFire = Time.time + fireRate;
    nearEnemy.transform.parent.GetComponent<enemy>().health = nearEnemy.transform.parent.GetComponent<enemy>().health - hasar;// hasari randomda al(belki)
}
}
void baseAttac(){
    anim.SetInteger("komut",3);
    if(Time.time > nextFire){
        rb.velocity = transform.forward * 0;
        nextFire = Time.time + fireRate;
        GameObject.Find("spawner").GetComponent<index>().enemyBase = GameObject.Find("spawner").GetComponent<index>().enemyBase - hasarBase;
    }
}
}