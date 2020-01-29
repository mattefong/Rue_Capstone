using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerMovement : MonoBehaviour
{
    private SC_Collision coll;
    [HideInInspector]
    private Rigidbody2D rb;
    private SC_AnimationScript anim;

    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float jumpForce = 50;
    public float slideSpeed = 5;
    public float wallJumpLerp = 10;

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool wallSlide;
    public bool wallJumped;

    [Space]
    [Header("Polish")]
    public ParticleSystem jumpParticle;

    [Space]
    private bool groundTouch;
    public int side = 1;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    void Start()
    {
        coll = GetComponent<SC_Collision>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<SC_AnimationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        anim.SetHorizontalMovement( x, y, rb.velocity.y);

        if (coll.onWall && canMove)
        {
            if (side != coll.wallSide)
                anim.Flip(side * -1);
            wallSlide = false;
        }

        if (!coll.onWall || !canMove)
        {
            wallSlide = false;
        }

        if (coll.onGround)
        {
            wallJumped = false;
            GetComponent<SC_BetterJump>().enabled = true;
        }
        else
        {
            rb.gravityScale = 2.5f;
        }

        //Wall Slide
        if (coll.onWall && !coll.onGround)
        {
            if (x != 0)
            {
                wallSlide = true;
                WallSlide();
            }
        }

        if (!coll.onWall || coll.onGround)
            wallSlide = false;

        //Jump Input
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");

            if (coll.onGround)
                Jump(Vector2.up, false);
            if (coll.onWall && !coll.onGround)
                WallJump();
        }

        if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if (!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        if (wallSlide || !canMove)
            return;

        if (x > 0)
        {
            side = 1;
            anim.Flip(side);
            //Flip();
        }
        if (x < 0)
        {
            side = -1;
            anim.Flip(side);
            //Flip();
        }
    }

    void GroundTouch()
    {
        side = anim.sr.flipX ? -1 : 1;
    }

    //Wall Jump
    private void WallJump()
    {
        if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
        {
            side *= -1;
            anim.Flip(side);
        }

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.1f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up / 1.5f + wallDir / 1.5f), true);

        wallJumped = true;
    }

    //Wall Slide
    private void WallSlide()
    {
        if (coll.wallSide != side)
            anim.Flip(side * 1);

        if (!canMove)
            return;

        bool pushingWall = false;
        if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;

        rb.velocity = new Vector2(push, -slideSpeed);
    }

    //Walk
    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    //Jump
    private void Jump(Vector2 dir, bool wall)
    {
        ParticleSystem particle = jumpParticle;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

        particle.Play();
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= side;
        transform.localScale = theScale;
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
