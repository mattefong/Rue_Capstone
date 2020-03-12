using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, maxMana, invincibilityDurationSeconds, delayBetweenInvincibilityFlashes;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private float currentHealth, currentMana;

    private bool isInvincible = false;

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
        if (isInvincible) return;

        if(currentHealth <= 0.0f)
        {
            Die();
            return;
        }

        StartCoroutine(BecomeTemporariltyInvincible());
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


    //Invincibility Frames
    private IEnumerator BecomeTemporariltyInvincible()
    {
        //logic
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for(float i = 0; i < invincibilityDurationSeconds; i += delayBetweenInvincibilityFlashes)
        {
            yield return new WaitForSeconds(delayBetweenInvincibilityFlashes);
        }

        Debug.Log("Player is no longer invincible!");
        isInvincible = false;
    }
}
