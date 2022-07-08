/*
---Creation of Jonfoble---
*/
using UnityEngine;
public class GameOver : MonoBehaviour
{
	public GameObject gameOverTextYouLose, gameOverTextYouWin, restartButton, spawnUI, levelUp;
	private void Start()
	{
		gameOverTextYouLose.SetActive(false);
		gameOverTextYouWin.SetActive(false);
		restartButton.SetActive(false);

	}
	public void Update()
	{
		if (GameObject.Find("spawner").GetComponent<index>().enemyBase <= 0)
		{
			PauseGame();
			gameOverTextYouWin.SetActive(true);
			restartButton.SetActive(true);
			spawnUI.SetActive(false);
			levelUp.SetActive(false);
		}
		else if (GameObject.Find("spawner").GetComponent<index>().allyBase <= 0)
		{
			PauseGame();
			gameOverTextYouLose.SetActive(true);
			restartButton.SetActive(true);
			spawnUI.SetActive(false);
			levelUp.SetActive(false);
		}
	}
	public void PauseGame()
	{
		
		Time.timeScale = 0;
	}
	public void ResumeGame()
	{
		Time.timeScale = 1;

	}
}
