using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_NextArea : MonoBehaviour
{
    public GameObject levelLoader;

    private SC_LevelLoader loader;

    void Start()
    {
        loader = levelLoader.GetComponent<SC_LevelLoader>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            loader.LoadNextLevel();
        }
    }

}
