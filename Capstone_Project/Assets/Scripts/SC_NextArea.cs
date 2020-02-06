using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_NextArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKeyDown("w") && collision.gameObject.name == "NextArea")
        {
            Debug.Log("Entered");
            //SceneManager.LoadScene("Playtest");
        }
        Debug.Log("Entered");
    }
}
