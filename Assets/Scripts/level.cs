using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level : MonoBehaviour
{
    public GameObject levelButton;
    public GameObject neededxp;
    public TMPro.TMP_Text levelTEXT;
    public int xp = 0;
    public int xpE = 0;
    public int levelNow = 1;
    public int levelNowE = 1;
    public int level2xp = 1000;
    public int level3xp = 3000;
    public int neededNext = 0;
	

	private void Update()
	{
        if (levelNow == 3)
        {
            xp = 10000;

            neededxp.GetComponent<TextMeshProUGUI>().text = "MAX LEVEL";

        }
		if (levelNow == 1)
		{
            neededNext = level2xp - xp;
            neededxp.GetComponent<TextMeshProUGUI>().text = "Need " + neededNext.ToString() + " More Xp";
            
        }
		if (levelNow == 2)
		{

            neededNext = level3xp - xp;

            neededxp.GetComponent<TextMeshProUGUI>().text = "Need " + neededNext.ToString() + " More Xp";
        }
    }

	private void FixedUpdate()
    {
        GameObject.Find("xp").GetComponent<TextMeshProUGUI>().text = xp.ToString() + " xp";
        levelTEXT.text = "Age : " + levelNow;
        levelNowE = levelNow;
		
    }
    public void levelUp()
    {

        Vector3 textPlace = new Vector3(levelButton.transform.position.x+200, levelButton.transform.position.y, levelButton.transform.position.z);
        if (levelNow == 1){
            if(xp > level2xp){
                levelNow = 2;
                //level2
                Debug.Log("level 2");
            }
            else{
                Instantiate(neededxp, textPlace, Quaternion.identity, transform);
            }
        }
        else if(levelNow == 2){
            if(xp > level3xp){
                levelNow = 3;
                //level3
                Debug.Log("level 3");
            }
            else{

                Instantiate(neededxp, textPlace, Quaternion.identity, transform);
            }
        }

    }

}
