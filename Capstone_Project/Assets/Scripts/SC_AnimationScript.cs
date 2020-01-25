using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AnimationScript : MonoBehaviour
{
    private Animator anim;
    private SC_PlayerMovement move;
    private SC_Collision coll;
    [HideInInspector]
    public SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInParent<SC_Collision>();
        move = GetComponentInParent<SC_PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        anim.SetBool("onGround", coll.onGround);
        anim.SetBool("onWall", coll.onWall);
        anim.SetBool("onRightWall", coll.onRightWall);
        anim.SetBool("wallSlide", move.wallSlide);
        anim.SetBool("canMove", move.canMove);

    }

    public void SetHorizontalMovement(float x, float y, float yVel)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("HorizontalSpeed", Mathf.Abs(x));
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void Flip(int side)
    {

        if (move.wallSlide)
        {
            if (side == -1 && sr.flipX)
                return;

            if (side == 1 && !sr.flipX)
            {
                return;
            }
        }

        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
