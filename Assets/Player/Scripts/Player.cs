using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    float horizontalMovement;



    [Header("Jump")]
    public float jumpForce = 5f;
    public int maxJumps = 2;
    public int JumpsRemaining { get; private set; }



    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;




    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;



    Rigidbody2D rb;
    public float CurrentSpeed { get; private set; }
    public System.Action OnJumpEvent;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GroundCheck();
        Gravity();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * walkSpeed, rb.velocity.y);
        CurrentSpeed = Mathf.Abs(rb.velocity.x);
    }

    public void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }


    public void OnJump(InputAction.CallbackContext context)
    {
        if (JumpsRemaining > 0)
        {
            if (context.started)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                JumpsRemaining--;
                print(JumpsRemaining);
                
                OnJumpEvent?.Invoke();
            }    
        }
    }


    private void GroundCheck()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            JumpsRemaining = maxJumps;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
