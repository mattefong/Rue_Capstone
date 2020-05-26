using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyLineOfSight : MonoBehaviour
{
    [SerializeField]
    GameObject skeleton;
    Animator skeletonAnim;

    [SerializeField]
    Transform player;

    public GameObject skeletonGO;

    [SerializeField]
    float 
        agroRange,
        stoppingDistance;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    private SC_Skeleton skeletonScript;

    private bool isWalking;
    private float distToPlayer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        skeletonAnim = skeleton.GetComponent<Animator>();

        skeletonScript = skeletonGO.GetComponent<SC_Skeleton>();

        skeletonScript.currentHealth = skeletonScript.maxHealth;
    }

    void Update()
    {
        //float distToPlayer = Vector2.Distance(transform.position, player.position);
        distToPlayer = Mathf.Abs(transform.position.x - player.position.x);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }


        if (skeletonScript.currentHealth <= 0.0f)
        {
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        //Attack
        if(distToPlayer <= stoppingDistance)
        {
            rb2d.velocity = new Vector2(0, 0);
            skeletonAnim.SetTrigger("isAttacking");
            skeletonAnim.SetBool("isWalking", false);
        }
        //Chase
        else if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            skeletonAnim.SetBool("isWalking", true);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            skeletonAnim.SetBool("isWalking", true);
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        skeletonAnim.SetBool("isWalking", false);
    }
}
