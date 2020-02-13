using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_NextArea : MonoBehaviour
{

    public GameObject prompt;

    void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);

        if(collision && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("u gone");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
    }

}
