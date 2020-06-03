using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpPower;
    public int side;
    public bool facingRight;
    public Transform characterContainer;

    private Animator anim;
    private Rigidbody2D rb;
    private NEW_Collision collision;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<NEW_Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y);
        Run(direction);
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
            Jump(Vector2.up);
        }


        anim.SetFloat("HorizontalAxis", direction.x);
        anim.SetBool("OnGround", collision.onGround);

        if(x > 0)
        {
            side = -1;
            Vector3 theScale = characterContainer.transform.localScale;
            if (facingRight)
            {
                theScale.x *= -1;
                characterContainer.transform.localScale = theScale;
                facingRight = false;
            }
        }
        if (x < 0)
        {
            side = 1;
            Vector3 theScale = characterContainer.transform.localScale;
            if (!facingRight)
            {
                theScale.x *= -1;
                characterContainer.transform.localScale = theScale;
                facingRight = true;
            }
        }
    }

    public void Run(Vector2 dir)
    {
        rb.velocity = new Vector2 (dir.x * runSpeed, rb.velocity.y);
    }

    public void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
    }
}
