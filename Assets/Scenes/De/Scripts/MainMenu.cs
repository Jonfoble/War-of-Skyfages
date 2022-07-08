using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public TMPro.TMP_Dropdown difficultyDropdown;
    public int sceneToLoadIndex;
	private void Start()
	{
		difficultyDropdown.value = 1;
		difficultyDropdown.RefreshShownValue();
	}
	public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneToLoadIndex);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficulty(int sceneIndex)
	{
		if (difficultyDropdown.value == 1)
		{
            sceneToLoadIndex = 1;
		}
		else if (difficultyDropdown.value == 0)
		{
            sceneToLoadIndex = 2;
		}
		else if (difficultyDropdown.value == 2)
		{
            sceneToLoadIndex = 3;
		}
	}
}
