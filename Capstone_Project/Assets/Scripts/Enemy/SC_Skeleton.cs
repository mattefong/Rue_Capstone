using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Skeleton : MonoBehaviour
{
    [SerializeField]
    private float knockbackSpeedX, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque;

    public float maxHealth;

    [SerializeField]
    private bool applyKnockback;

    //Holds Hit Particle Effect
    [SerializeField]
    private GameObject hitParticle;

    private float knockbackStart;

    public float currentHealth;

    public float speed;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback, checkTrigger;

    private SC_PlayerMovement pc;
    private GameObject aliveGO;
    private Rigidbody2D rbAlive, rbDead;
    private Animator aliveAnim;

    public Transform target;

    private void Start()
    {
        currentHealth = maxHealth;

        pc = GameObject.Find("Player").GetComponent<SC_PlayerMovement>();

        aliveGO = transform.Find("Alive").gameObject;

        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        CheckKnockBack();
    }

    private void Damage(float amount)
    {
        currentHealth -= amount;
        playerFacingDirection = pc.GetFacingDirection();

        Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        if (playerFacingDirection == 1)
        {
            playerOnLeft = true;
        }
        else
        {
            playerOnLeft = false;
        }

        //aliveAnim.SetBool("playerOnLeft", playerOnLeft);
        //aliveAnim.SetTrigger("damage");

        if (applyKnockback && currentHealth > 0.0f)
        {
            //Knockback
            KnockBack();

        }
        if (currentHealth <= 0.0f)
        {
            //Die
            Die();
        }
    }

    private void KnockBack()
    {
        knockback = true;
        knockbackStart = Time.time;
        rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
        aliveAnim.SetTrigger("isHurt");
    }

    private void CheckKnockBack()
    {
        if (Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y);
        }
    }

    private void Die()
    {
        //rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
        aliveAnim.SetBool("isDead", true);
        GetComponentInChildren<Collider2D>().enabled = false;
        GetComponentInChildren<Rigidbody2D>().gravityScale = 0;
        this.enabled = false;
    }

    private void Follow()
    {
        if (checkTrigger)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            checkTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            checkTrigger = false;
        }
    }
}
