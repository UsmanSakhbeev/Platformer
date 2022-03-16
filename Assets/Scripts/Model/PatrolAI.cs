using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;

    private float distanceToPlayer;
    private bool mustPatrol;
    private bool mustTurn;
    private bool mustChase;
    private RaycastHit2D groundInfo;
    private Animator anim;

    public Rigidbody2D rb;
    public float speed;
    public LayerMask groundLayer;
    public Collider2D bodyColluder;
    public Transform groundDetection;


    private void Awake()
    {        
        anim = GetComponent<Animator>();       
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
    }
    private void Update()
    {
        GroundChecking();
        PlayerSearching();
        distanceToPlayer = Vector2.Distance(transform.position, player.position);        
        if (mustPatrol)
        {
            Patrol();
        }
        if (mustChase)
        {
            PlayerChase();
        }        
    }
    void Patrol()
    {
        anim.Play("run");
        rb.velocity = new Vector2(speed, 0);        
        if (mustTurn || bodyColluder.IsTouchingLayers(groundLayer)) 
        {
            Flip();
            mustTurn = false;
        }
    }
    void  PlayerChase()
    {
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(1, 1);
            rb.velocity = new Vector2(Mathf.Abs(speed), 0);
        }
        else if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(-Mathf.Abs(speed), 0);
        }
    }
    void Flip()
    {
        mustPatrol = false;
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        speed *= -1;
        mustPatrol = true;
    }
    void GroundChecking()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2);        
        if (groundInfo.collider == null)
        {
            mustTurn = true;
        }
    }
    void PlayerSearching()
    {
        if(distanceToPlayer <= agroRange)
        {
            mustPatrol = false;
            mustChase = true;
        }
        else
        {
            mustPatrol = true;
            mustChase = false;
        }
    }
}


