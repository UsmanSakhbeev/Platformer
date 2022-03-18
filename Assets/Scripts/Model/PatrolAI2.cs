using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI2 : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] Animator animator;
    [SerializeField] Vector2 leftPosition;
    [SerializeField] Vector2 rightPosition;

    private float _distanceToPlayer;
    private bool _mustPatrol;
    private bool _mustChase;
    private bool _mustReturn;
    private bool _moveRight;
    
    private RaycastHit2D _groundInfo;
    private Collider2D _playerInfo;
    
    public Rigidbody2D rb;
    public float speed;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform groundDetection;


    private void Awake()
    {
        _distanceToPlayer = Vector2.Distance(transform.position, player.position);
        _moveRight = true;
    }
    private void Update()
    {
        GroundChecking();
        if(_mustReturn != true)
            PlayerSearching();
        if (_mustPatrol)
        {
            Patrol();
        }
        else if (_mustChase == true && _mustReturn == false)
        {
            PlayerChase();
        }
    }
    void Patrol()
    {
        animator.Play("run");
        if(_moveRight == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPosition, speed * Time.deltaTime);
            if(transform.position.x == rightPosition.x)
            {
                transform.localScale = new Vector2(-1, 1);
                _moveRight = false;
                _mustReturn = false;
            }                
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPosition, speed * Time.deltaTime);
            if (transform.position.x == leftPosition.x)
            {
                transform.localScale = new Vector2(1, 1);
                _moveRight = true;
                _mustReturn = false;
            }
        }
    }
    void PlayerChase()
    {
        if (transform.position.x < player.position.x)
        {
            _moveRight = true;
            transform.localScale = new Vector2(1, 1);
            rb.velocity = new Vector2(Mathf.Abs(speed), 0);
        }
        else if (transform.position.x > player.position.x)
        {
            _moveRight = false;
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = new Vector2(-Mathf.Abs(speed), 0);
        }
    }

    void GroundChecking()
    {
        _groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2);
        if (_groundInfo.collider == null)
        {
            _mustReturn = true;
            _mustChase = false;
            _mustPatrol = true;
            SetDirection();
        }

        if (bodyCollider.IsTouchingLayers(groundLayer))
        {
            _mustReturn = true;
            _mustChase = false;
            _mustPatrol = true;
            SetDirection();
        }
    }
    void PlayerSearching()
    {
        _playerInfo = Physics2D.OverlapCircle(transform.position, 5, LayerMask.GetMask("Player"));
        if (_playerInfo)
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
    void SetDirection()
    {
        if (Vector2.Distance(transform.position, leftPosition) < Vector2.Distance(transform.position, rightPosition))
        {
            _moveRight = true;
            transform.localScale = new Vector2(1, 1);
        }            
        else
        {
            _moveRight = false;
            transform.localScale = new Vector2(-1, 1);
        }
    }
}


