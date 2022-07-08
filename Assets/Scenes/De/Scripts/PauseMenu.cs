/*
---Creation of Jonfoble---
*/
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
	public GameObject PauseMenuUI;
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{



			if (isPaused)
			{
				Resume();

			}else
			{
				Pause();

			}

		}



    }

	public void Resume()
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1;
		isPaused = false;
	}
	public void Pause()
	{
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0;
		isPaused = true;
	}
	public void LoadMenu()
	{

		SceneManager.LoadScene("Menu");
	}
	public void QuitGame()
	{

		Application.Quit();

	}
}
