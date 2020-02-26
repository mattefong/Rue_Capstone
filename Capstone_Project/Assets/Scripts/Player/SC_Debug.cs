using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Debug : MonoBehaviour
{
    public GameObject menuUI;

    void Start()
    {
        menuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DebugKey();
        MenuKey();
    }

    void DebugKey()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void MenuKey()
    {
        if (Input.GetKey(KeyCode.P))
        {
            menuUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
