using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OLD_SC_PlayerCombat : MonoBehaviour
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

    //public int hitCounter = 0;

    private float lastInputTime = Mathf.NegativeInfinity;

    public float[] attackDetails = new float[2];

    private Animator anim;

    private SC_PlayerMovement PC;
    private SC_PlayerStats PS;

    public GameObject damageNumber;

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
        if (Input.GetButtonDown("Fire1"))
        {
            if (combatEnabled)
            {
                //Attempt combat
                gotInput = true;
                lastInputTime = Time.time;
            }
        }

        //if (timeBtwShots <= 0)
        //{
        //    GameObject g = Instantiate(projectile, firePosition.position, transform.rotation);
        //    g.GetComponent<SC_Projectile>().direction = PC.GetFacingDirection();
        //    timeBtwShots = startTimeBtwShots;
        //}
        //else
        //{
        //    timeBtwShots -= Time.deltaTime;
        //}
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
                anim.SetBool("attack1", true);
                anim.SetBool("isAttacking", isAttacking);
                isFirstAttack = !isFirstAttack;
                anim.SetBool("firstAttack", isFirstAttack);
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
            
            //Damage Number Pop Up
            var clone = (GameObject) Instantiate(damageNumber, attack1HitBoxPos.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<SC_FloatingNumbers>().damageNumber = whatIsDamageable;
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
