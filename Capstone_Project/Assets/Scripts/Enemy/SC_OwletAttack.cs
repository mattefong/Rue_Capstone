using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_OwletAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            SC_Owlet.isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            SC_Owlet.isAttacking = false;
        }
    }
}
