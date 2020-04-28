using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_WorldMap : MonoBehaviour
{
    public GameObject playerUI, worldCamera, playerCamera, brainCamera;
    
    bool isOpen;

    void Start()
    {
        worldCamera.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            if (!isOpen)
            {
                OpenMap();
            }
            else if (isOpen)
            {
                CloseMap();
            }
        }
    }

    void OpenMap()
    {
        Time.timeScale = 0.0f;
        isOpen = true;
        playerUI.SetActive(false);
        worldCamera.SetActive(true);
        playerCamera.SetActive(false);
        brainCamera.SetActive(false);
    }

    void CloseMap()
    {
        Time.timeScale = 1.0f;
        isOpen = false;
        playerUI.SetActive(true);
        worldCamera.SetActive(false);
        playerCamera.SetActive(true);
        brainCamera.SetActive(true);
    }

}
