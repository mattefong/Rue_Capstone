﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private float currentHealth;

    private SC_GameManager GM;

    public GameObject healthBar;

    public void Update()
    {
        healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<SC_GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        Destroy(gameObject);
    }
}
