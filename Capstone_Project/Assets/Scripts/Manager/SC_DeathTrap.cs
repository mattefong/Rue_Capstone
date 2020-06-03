using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DeathTrap : MonoBehaviour
{
    public GameObject deathTrap;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(deathTrap);
        }
    }

}
