using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    //Combo
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.9f;

    //Attack
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);



            //if( !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle") )
            //{
            //animator.Play("Player_Idle");
            //}

        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

                //Combo
                lastClickedTime = Time.time;
                noOfClicks++;
                if(noOfClicks == 1)
                {
                    animator.SetBool("Attack1", true);
                }
                else if(noOfClicks == 2)
                {
                    animator.SetBool("Attack2", true);
                }
                else if (noOfClicks == 3)
                {
                    animator.SetBool("Attack3", true);
                }

                noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

            }
        }
    }

    public void return1()
    {
        if (noOfClicks >= 2)
        {
            animator.SetBool("Attack2", true);
        }
        else
        {
            animator.SetBool("Attack1", false);
            noOfClicks = 0;
        }
    }

    public void return2()
    {
        if (noOfClicks >= 3)
        {
            animator.SetBool("Attack3", true);
        }
        else
        {
            animator.SetBool("Attack2", false);
            noOfClicks = 0;
        }
    }

    public void return3()
    {
        if (noOfClicks >= 2)
        {
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Attack3", false);
            noOfClicks = 0;
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);

        //Damage Them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<SC_Enemy>().TakeDamage(attackDamage);
        }
    
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
