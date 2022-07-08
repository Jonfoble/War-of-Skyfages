/*
---Creation of Jonfoble---
*/
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoBackToMenu : MonoBehaviour
{
    public void GoToMainMenu()
	{
        SceneManager.LoadScene("Menu");
    }
}
