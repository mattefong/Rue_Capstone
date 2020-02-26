using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Menu : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Scene_1");
    }

    public void LoadSceneTest()
    {
        SceneManager.LoadScene("Scene_Test");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeMenu()
    {
        Time.timeScale = 1.0f;
    }

}
