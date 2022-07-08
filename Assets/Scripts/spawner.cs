using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class spawner : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    public GameObject alliedI;
    public GameObject enemyI;
    public GameObject okcu;
    public GameObject kilicli;
    public GameObject kilicliE;
    public GameObject okcuE;
    public GameObject paraStr;
    Vector3 spawnPoint;
    int sira = 1;
    private float _passedTime;
    private float _passedTime2;
    public int para = 0;
    public bool spwnd = false;

    public int paraE = 100;
    int siraE = 1;
    GameObject spawnOlacakE;
    float totBaski;
    Vector3 spawnPointE;
    bool atildi;



    float yogunluk1;
    float yogunluk2;
    float yogunluk3;
    float yogunluk4;
    float yogunluk5;
    GameObject[] Nyol1dusman;
    GameObject[] Nyol2dusman;
    GameObject[] Nyol3dusman;
    GameObject[] Nyol4dusman;
    GameObject[] Nyol5dusman;
    int[] yol1dusman;
    int[] yol2dusman;
    int[] yol3dusman;
    int[] yol4dusman;
    int[] yol5dusman;



    float Eyogunluk1;
    float Eyogunluk2;
    float Eyogunluk3;
    float Eyogunluk4;
    float Eyogunluk5;
    GameObject[] ENyol1dusman;
    GameObject[] ENyol2dusman;
    GameObject[] ENyol3dusman;
    GameObject[] ENyol4dusman;
    GameObject[] ENyol5dusman;
    float[] Eyol1dusman;
    float[] Eyol2dusman;
    float[] Eyol3dusman;
    float[] Eyol4dusman;
    float[] Eyol5dusman;


    float baski1; 
    float baski2;
    float baski3;
    float baski4;
    float baski5;

    float yol1Yuzde;
    float yol2Yuzde;
    float yol3Yuzde;
    float yol4Yuzde;
    float yol5Yuzde;


    public float yol1para;
    public float yol2para;
    public float yol3para;
    public float yol4para;
    public float yol5para;

    public int yol1atilacak;
    public int yol2atilacak;
    public int yol3atilacak;
    public int yol4atilacak;
    public int yol5atilacak;

    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;

    bool initialSpawn = false;

    // uzaktan sikan savascilarin mesafesine biraz ekle ki uzaktaykende baski base ye deyiyormus gibi olsun



    GameObject spawnOlacak;
	private void Start() {
        {
            initialSpawn = false;

            yol1atilacak = randomEnemy();
    yol2atilacak = randomEnemy();
    yol3atilacak = randomEnemy();
    yol4atilacak = randomEnemy();
    yol5atilacak = randomEnemy();}
    spawnPoint = GameObject.Find("Cylinder").transform.position;
    }
    
    public void yap1(){
        spawnPoint = GameObject.Find("Cylinder").transform.position;
        c1.GetComponent<Renderer>().material.color = Color.blue;
        c2.GetComponent<Renderer>().material.color = Color.white;
        c3.GetComponent<Renderer>().material.color = Color.white;
        c4.GetComponent<Renderer>().material.color = Color.white;
        c5.GetComponent<Renderer>().material.color = Color.white;
        
        sira = 1;
    }
    public void yap2(){
        spawnPoint = GameObject.Find("Cylinder1").transform.position;
        c1.GetComponent<Renderer>().material.color = Color.white;
        c2.GetComponent<Renderer>().material.color = Color.blue;
        c3.GetComponent<Renderer>().material.color = Color.white;
        c4.GetComponent<Renderer>().material.color = Color.white;
        c5.GetComponent<Renderer>().material.color = Color.white;
        sira = 2;
    }
    public void yap3(){
        spawnPoint = GameObject.Find("Cylinder2").transform.position;
       c1.GetComponent<Renderer>().material.color = Color.white;
        c2.GetComponent<Renderer>().material.color = Color.white;
        c3.GetComponent<Renderer>().material.color = Color.blue;
        c4.GetComponent<Renderer>().material.color = Color.white;
        c5.GetComponent<Renderer>().material.color = Color.white;
        sira = 3;
    }
    public void yap4(){
        spawnPoint = GameObject.Find("Cylinder3").transform.position;
        c1.GetComponent<Renderer>().material.color = Color.white;
        c2.GetComponent<Renderer>().material.color = Color.white;
        c3.GetComponent<Renderer>().material.color = Color.white;
        c4.GetComponent<Renderer>().material.color = Color.blue;
        c5.GetComponent<Renderer>().material.color = Color.white;
        sira = 4;
    }
    public void yap5(){
        spawnPoint = GameObject.Find("Cylinder4").transform.position;
        c1.GetComponent<Renderer>().material.color = Color.white;
        c2.GetComponent<Renderer>().material.color = Color.white;
        c3.GetComponent<Renderer>().material.color = Color.white;
        c4.GetComponent<Renderer>().material.color = Color.white;
        c5.GetComponent<Renderer>().material.color = Color.blue;
        sira = 5;
    }
    public void ally1(){
        int coinDecrement = 0;
        if (GameObject.Find("spawner").GetComponent<level>().levelNow == 1)
        {
            coinDecrement = 20;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 2)
        {
            coinDecrement = 30;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 3)
        {
            coinDecrement = 35;
        }

        if (para > coinDecrement)
        {
            para -= coinDecrement;
            spawnOlacak = alliedI;
            allied();
        }
        else
        {
            Debug.Log("Insufficient Money");
        }

        

        

        
    }
    public void ally2(){
        int coinDecrement = 0;
        if (GameObject.Find("spawner").GetComponent<level>().levelNow == 1)
        {
            coinDecrement = 20;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 2)
        {
            coinDecrement = 30;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 3)
        {
            coinDecrement = 40;
        }
        if (para > coinDecrement)
        {
            para -= coinDecrement;
            spawnOlacak = okcu;
            allied();
        }
        else
        {
            Debug.Log("Insufficient Money");
        }
    }
    public void ally3()
    {
        int coinDecrement = 0;
        if (GameObject.Find("spawner").GetComponent<level>().levelNow == 1)
        {
            coinDecrement = 60;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 2)
        {
            coinDecrement = 60;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 3)
        {
            coinDecrement = 60;
        }
        if (para > coinDecrement)
        {
            para -= coinDecrement;
            spawnOlacak = kilicli;
            allied();
        }
        else
        {
            Debug.Log("Insufficient Money");
        }
    }




    public void allied()
    {


        
        if(sira == 1){
        GameObject.Find("spawner").GetComponent<index>().indexno1++;}
        if(sira == 2){
        GameObject.Find("spawner").GetComponent<index>().indexno2++;}
        if(sira == 3){
        GameObject.Find("spawner").GetComponent<index>().indexno3++;}
        if(sira == 4){
        GameObject.Find("spawner").GetComponent<index>().indexno4++;}
        if(sira == 5){
        GameObject.Find("spawner").GetComponent<index>().indexno5++;}

        initialSpawn = true;
        Instantiate(spawnOlacak, spawnPoint, Quaternion.Euler(0, -90, 0));
    }


private void Update() {

		if (para < 0)
		{
            para = 0;
		}
        AI();

        int coinIncrement = 0;
        int coinIncrementE = 0;
		if (GameObject.Find("spawner").GetComponent<level>().levelNow == 1)
		{
            coinIncrement = 15;
		}
		else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 2)
		{
            coinIncrement = 25;
		}
		else if (GameObject.Find("spawner").GetComponent<level>().levelNow == 3)
		{
            coinIncrement = 30;
		}
		if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 1)
		{
            coinIncrementE = 20;
		}
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 2)
        {
            coinIncrementE = 25;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 3)
        {
            coinIncrementE = 30;
        }


        atildi = false;


_passedTime += Time.deltaTime;

        if (_passedTime > 1f && initialSpawn)
        {
            _passedTime = 0;
            para += coinIncrement;
            paraE += coinIncrementE;
            
        }
		else if (_passedTime2 > 3.5f) //spawn delayer 
		{

            spwnd = false;
            _passedTime2 = 0;
		}
        paraStr.GetComponent<TextMeshProUGUI>().text = para.ToString();
    
}
    public void AI(){
{
    yogunluk1 = 0;
    yogunluk2 = 0;
    yogunluk3 = 0;
    yogunluk4 = 0;
    yogunluk5 = 0;

    Eyogunluk1 = 0;
    Eyogunluk2 = 0;
    Eyogunluk3 = 0;
    Eyogunluk4 = 0;
    Eyogunluk5 = 0;

    Nyol1dusman = GameObject.FindGameObjectsWithTag("sira1");
    Nyol2dusman = GameObject.FindGameObjectsWithTag("sira2");
    Nyol3dusman = GameObject.FindGameObjectsWithTag("sira3");
    Nyol4dusman = GameObject.FindGameObjectsWithTag("sira4");
    Nyol5dusman = GameObject.FindGameObjectsWithTag("sira5");

    ENyol1dusman = GameObject.FindGameObjectsWithTag("Esira1");
    ENyol2dusman = GameObject.FindGameObjectsWithTag("Esira2");
    ENyol3dusman = GameObject.FindGameObjectsWithTag("Esira3");
    ENyol4dusman = GameObject.FindGameObjectsWithTag("Esira4");
    ENyol5dusman = GameObject.FindGameObjectsWithTag("Esira5");

    foreach(GameObject dusman in Nyol1dusman)
    {
        yogunluk1 += dusman.transform.parent.GetComponent<solider>().yogunlukMy;
    }
    foreach (GameObject dusman in Nyol2dusman)
    {
        yogunluk2 += dusman.transform.parent.GetComponent<solider>().yogunlukMy;
    }
    foreach (GameObject dusman in Nyol3dusman)
    {
        yogunluk3 += dusman.transform.parent.GetComponent<solider>().yogunlukMy;
    }
    foreach (GameObject dusman in Nyol4dusman)
    {
        yogunluk4 += dusman.transform.parent.GetComponent<solider>().yogunlukMy;
    }
    foreach (GameObject dusman in Nyol5dusman)
    {
        yogunluk5 += dusman.transform.parent.GetComponent<solider>().yogunlukMy;
    }


    foreach(GameObject dusman in ENyol1dusman)
    {
        Eyogunluk1 += dusman.transform.parent.GetComponent<enemy>().yogunlukMy;
    }
    foreach (GameObject dusman in ENyol2dusman)
    {
        Eyogunluk2 += dusman.transform.parent.GetComponent<enemy>().yogunlukMy;
    }
    foreach (GameObject dusman in ENyol3dusman)
    {
        Eyogunluk3 += dusman.transform.parent.GetComponent<enemy>().yogunlukMy;
    }
    foreach (GameObject dusman in ENyol4dusman)
    {
        Eyogunluk4 += dusman.transform.parent.GetComponent<enemy>().yogunlukMy;
    }
    foreach (GameObject dusman in ENyol5dusman)
    {
        Eyogunluk5 += dusman.transform.parent.GetComponent<enemy>().yogunlukMy;
    }

    baski1 = yogunluk1 - Eyogunluk1;
    baski2 = yogunluk2 - Eyogunluk2;
    baski3 = yogunluk3 - Eyogunluk3;
    baski4 = yogunluk4 - Eyogunluk4;
    baski5 = yogunluk5 - Eyogunluk5;

    if(baski1 < 0){
        baski1 = 0;
    }
    if(baski2 < 0){
        baski2 = 0;
    }
    if(baski3 < 0){
        baski3 = 0;
    }
    if(baski4 < 0){
        baski4 = 0;
    }
    if(baski5 < 0){
        baski5 = 0;
    }

    totBaski = baski1+baski2+baski3+baski4+baski5;

    yol1Yuzde = baski1/totBaski;
    yol2Yuzde = baski2/totBaski;
    yol3Yuzde = baski3/totBaski;
    yol4Yuzde = baski4/totBaski;
    yol5Yuzde = baski5/totBaski;
        }

            yol1para = paraE;
            yol2para = paraE;
            yol3para = paraE;
            yol4para = paraE;
            yol5para = paraE;
        


        if (randomizeSpawns() == 1)
        {
            if (yol1atilacak == 1 && yol1para > 20)
            {
                siraE = 1;
                enemy1();
                yol1atilacak = randomEnemy();
            }
        }
        else if (randomizeSpawns() == 2)
        {

            if (yol1atilacak == 2 && yol1para > 30)
            {
                siraE = 1;
                enemy2();
                yol1atilacak = randomEnemy();
            }
        }
        else if (randomizeSpawns() == 3)
		{
            if (yol1atilacak == 3 && yol1para > 30)
            {
                siraE = 1;
                enemy3();
                yol1atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 4)
		{
            if (yol2atilacak == 1 && yol2para > 20)
            {
                siraE = 2;
                enemy1();
                yol2atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 5)
        {
            if (yol2atilacak == 2 && yol2para > 30)
            {
                siraE = 2;
                enemy2();
                yol2atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 6)
		{
            if (yol2atilacak == 3 && yol2para > 30)
            {
                siraE = 2;
                enemy3();
                yol2atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 7)
		{
            if (yol3atilacak == 1 && yol3para > 20)
            {
                siraE = 3;
                enemy1();
                yol3atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 8)
		{
            if (yol3atilacak == 2 && yol3para > 30)
            {
                siraE = 3;
                enemy2();
                yol3atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 9)
		{
            if (yol3atilacak == 3 && yol3para > 30)
            {
                siraE = 3;
                enemy3();
                yol3atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 10)
		{
            if (yol4atilacak == 1 && yol4para > 20)
            {
                siraE = 4;
                enemy1();
                yol4atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 11)
		{
            if (yol4atilacak == 2 && yol4para > 30)
            {
                siraE = 4;
                enemy2();
                yol4atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 12)
		{
            if (yol4atilacak == 3 && yol4para > 30)
            {
                siraE = 4;
                enemy3();
                yol4atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 13)
		{
            if (yol5atilacak == 1 && yol5para > 20)
            {
                siraE = 5;
                enemy1();
                yol5atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 14)
		{
            if (yol5atilacak == 2 && yol5para > 30)
            {
                siraE = 5;
                enemy2();
                yol5atilacak = randomEnemy();
            }
        }
		else if (randomizeSpawns() == 15)
		{
            if (yol5atilacak == 3 && yol5para > 30)
            {
                siraE = 5;
                enemy3();
                yol5atilacak = randomEnemy();
            }
        }
    }

    public int randomizeSpawns()
	{
        int x = Random.Range(0, 16);
        return x;

	}
    public int randomEnemy(){
        int x = Random.Range(0,300);
        
        if(x < 100){
            return 1;
        }
        else if(x >= 100 && x < 200){
            return 2;
        }
		else if (x >= 200)
		{
            return 3;
		}
		else
		{
            return 0;
        }
        
        
    }
    public void enemy1(){
        int coinDecrementE = 0;
		if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 1)
		{
            coinDecrementE = 20;
		}
       else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 2)
        {
            coinDecrementE = 30;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 3)
        {
            coinDecrementE = 40;
        }
        if (atildi == false && paraE > coinDecrementE){
            atildi = true;
            paraE -= coinDecrementE;
            spawnOlacakE = enemyI;
            enemy();
        }
            
        
    }
    public void enemy2(){
        int coinDecrementE = 0;
        if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 1)
        {
            coinDecrementE = 25;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 2)
        {
            coinDecrementE = 35;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 3)
        {
            coinDecrementE = 45;
        }
        if (atildi == false && paraE > coinDecrementE){
            atildi = true;
            paraE -= coinDecrementE;
            spawnOlacakE = okcuE;
            enemy();
        }
    }
    public void enemy3()
    {
        int coinDecrementE = 0;
        if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 1)
        {
            coinDecrementE = 40;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 2)
        {
            coinDecrementE = 45;
        }
        else if (GameObject.Find("spawner").GetComponent<level>().levelNowE == 3)
        {
            coinDecrementE = 60;
        }
        if (atildi == false && paraE > coinDecrementE)
        {
            atildi = true;
            paraE -= coinDecrementE;
            spawnOlacakE = kilicliE;
            enemy();
        }
    }

    public void enemy(){

        if (siraE == 1){
        spawnPointE = GameObject.Find("Cylinder5").transform.position;
        GameObject.Find("spawner").GetComponent<index>().enemyno1++;}
        if(siraE == 2){
        spawnPointE = GameObject.Find("Cylinder6").transform.position;
        GameObject.Find("spawner").GetComponent<index>().enemyno2++;}
        if(siraE == 3){
        spawnPointE = GameObject.Find("Cylinder7").transform.position;
        GameObject.Find("spawner").GetComponent<index>().enemyno3++;}
        if(siraE == 4){
        spawnPointE = GameObject.Find("Cylinder8").transform.position;
        GameObject.Find("spawner").GetComponent<index>().enemyno4++;}
        if(siraE == 5){
        spawnPointE = GameObject.Find("Cylinder9").transform.position;
        GameObject.Find("spawner").GetComponent<index>().enemyno5++;}

        spwnd = false;
        if (!spwnd)
        {
            Instantiate(spawnOlacakE, spawnPointE, Quaternion.Euler(0, 90, 0));
            spwnd = true;
        }



    }


}