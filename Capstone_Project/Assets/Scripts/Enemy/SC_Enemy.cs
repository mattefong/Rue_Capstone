using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enemy : MonoBehaviour
{
    //public GameObject deathEffect;
    private SC_Dummy dummy;

    // Start is called before the first frame update
    void Start()
    {
        dummy = GetComponent<SC_Dummy>();
    }

    private void Update()
    {
        //if (dummy.currentHealth < 0)
        //{
        //    Instantiate(deathEffect, transform.position, Quaternion.identity);
        //}
    }

    public void TakeDamage(float damage)
    {
        dummy.currentHealth -= damage;
    }
}
