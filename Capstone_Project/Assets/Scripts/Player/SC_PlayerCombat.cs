﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;

    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attack1HitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;

    private bool gotInput, isAttacking, isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;

    public float[] attackDetails = new float[2];

    public GameObject projectile;
    public Transform firePosition;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Animator anim;

    private SC_PlayerMovement PC;
    private SC_PlayerStats PS;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<SC_PlayerMovement>();
        PS = GetComponent<SC_PlayerStats>();
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                //Attempt combat
                gotInput = true;
                lastInputTime = Time.time;
            }
        }

        //Fireball
        if (Input.GetMouseButtonDown(1))
        {
            if(timeBtwShots <= 0)
            {
                GameObject g = Instantiate(projectile, firePosition.position, transform.rotation);
                g.GetComponent<SC_Projectile>().direction = PC.GetFacingDirection();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            //Perform Attack1
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
            }
        }

        if (Time.time >= lastInputTime + inputTimer)
        {
            //Wait for new input
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageable);

        attackDetails[0] = attack1Damage;
        attackDetails[1] = transform.position.x;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
            //Instantiate hit particle
        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }

    private void Damage(float[] attackDetails)
    {
        int direction;

        PS.DecreaseHealth(attackDetails[0]);

        //Damage player here using attackDetails[0]

        if(attackDetails[1] < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        PC.Knockback(direction);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
}
