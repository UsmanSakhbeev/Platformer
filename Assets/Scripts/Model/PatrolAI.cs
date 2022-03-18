using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] Animator animator;

    private float _distanceToPlayer;
    private bool _mustPatrol;
    private bool _mustTurn;
    private bool _mustChase;
    private RaycastHit2D _groundInfo;
    private RaycastHit2D _playerInfo;

    public Rigidbody2D rb;
    public float speed;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform groundDetection;


    private void Awake()
    {                
        _distanceToPlayer = Vector2.Distance(transform.position, player.position);
    }
    private void Update()
    {
        GroundChecking();
        PlayerSearching();
        _distanceToPlayer = Vector2.Distance(transform.position, player.position);        
        if (_mustPatrol)
        {
            Patrol();
        }
        if (_mustChase)
        {
            PlayerChase();
        }        
    }
    void Patrol()
    {
        animator.Play("run");
        rb.velocity = new Vector2(speed, 0);        
        if (_mustTurn || bodyCollider.IsTouchingLayers(groundLayer)) 
        {
            Flip();
            _mustTurn = false;
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
        _mustPatrol = false;
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        speed *= -1;
        _mustPatrol = true;
    }
    void GroundChecking()
    {
        _groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2);        
        if (_groundInfo.collider == null)
        {
            _mustTurn = true;
        }
    }
    void PlayerSearching()
    {
        //_playerInfo = Physics2D.CircleCast(transform.position, 5, Vector2., LayerMask.GetMask("Player"));
        if(_distanceToPlayer <= agroRange)
        {
            _mustPatrol = false;
            _mustChase = true;
        }
        else
        {
            _mustPatrol = true;
            _mustChase = false;
        }
    }
}


