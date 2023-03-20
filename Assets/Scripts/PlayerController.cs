using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed, jumpForce;
    private float idleX, idleY;
    private Vector2 _moveInput;
    public int jumpTime;
    public int jumpCounter;
    private bool jump;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    // private PlayerStates _currentstate;
    // public  PlayerStates Currentstate => _currentstate;
    public Animator anim;
    void Start()
    {
        jumpCounter = jumpTime;
        jump = false;
    }
    
    
    void Update()
    {
        BasicMovement();
        Jump();
    }


    private void BasicMovement()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");
        _moveInput.Normalize();

        rb.velocity = new Vector3(_moveInput.x * moveSpeed, rb.velocity.y, _moveInput.y * moveSpeed);
        if (_moveInput != Vector2.zero)
        {
            
            anim.SetBool("isMoving",true);
            idleX = _moveInput.x;
            idleY = _moveInput.y;
        }
        else
        {
            anim.SetBool("isMoving",false);
        }
        anim.SetFloat("InputX",idleX);
        anim.SetFloat("InputY",idleY);
    }

    private bool IsGround()
    {
        RaycastHit hit;
        return Physics.Raycast(groundPoint.position, Vector3.down, out hit, .1f, whatIsGround);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isIdle", false);
            
            if (IsGround())
            {
                anim.SetBool("isJumping", true);
                // rb.velocity += new Vector3(0f, jumpForce, 0f);
                rb.AddForce(transform.up * jumpForce,ForceMode.VelocityChange);
                jumpCounter = jumpTime;
            }
            else if (jumpCounter > 0)
            {
                anim.SetBool("isJumping", true);
                // rb.velocity += new Vector3(0f, jumpForce, 0f);
                rb.AddForce(transform.up * jumpForce,ForceMode.VelocityChange);
                jumpCounter--;
            }
        }
    }

    public void finishJump()
    {
        Debug.Log("yes");
        anim.SetBool("isJumping", false);
        anim.SetBool("isIdle", true);
    }
    
    
}
