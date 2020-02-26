using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, maxMana;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private float currentHealth, currentMana;

    private SC_GameManager GM;

    private Animator anim;

    public GameObject healthBar, manaBar;

    public void Update()
    {
        healthBar.transform.localScale = new Vector3(currentHealth / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.x);
        //manaBar.transform.localScale = new Vector3(currentMana / maxMana, manaBar.transform.localScale.y, manaBar.transform.localScale.x);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
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

    public void DecreaseMana(float amount)
    {
        currentMana -= amount;
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        Destroy(gameObject);
    }
}
