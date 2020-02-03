using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_RueFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;
    private Rigidbody2D rueRb;

    private bool isRunning;

    public Animator rueAnim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rueAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            var targetPos = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }

        rueAnim.Play("Rue_Running");
    }
}
