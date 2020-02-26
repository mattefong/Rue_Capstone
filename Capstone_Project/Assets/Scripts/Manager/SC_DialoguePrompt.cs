using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DialoguePrompt : MonoBehaviour
{

    public GameObject prompt;

    void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
    }
}
