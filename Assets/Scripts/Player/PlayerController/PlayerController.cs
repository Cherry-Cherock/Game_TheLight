using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //---------Player Setting--------------------
    public float moveSpeed;
    public float jumpForce;
    public int jumpTime;
    public Transform groundPoint;
    public Animator anim;
    //------------------------------------
    private PlayerControl inputSystem;
    public Rigidbody rb;
    private float idleX, idleY;
    private Vector2 _moveInput;
    private int jumpCounter;
    private bool jump;
    public LayerMask whatIsGround;

    private void Awake()
    {
        inputSystem = new PlayerControl();
    }

    private void OnEnable()
    {
        init();
    }


    void Update()
    {
        if (IsGround())
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", true);
        }
        BasicMovement();
    }

    private void init()
    {
        inputSystem.Enable();
        jumpCounter = jumpTime;
        jump = false;
        inputSystem.Player.Jump.performed += Jump;
    }

    #region Run
    public void BasicMovement()
    {
        _moveInput = inputSystem.Player.Movement.ReadValue<Vector2>();
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
    #endregion
    private bool IsGround()
    {
        RaycastHit hit;
        return Physics.Raycast(groundPoint.position, Vector3.down, out hit, .1f, whatIsGround);
    }

    #region Jump
    public void Jump(InputAction.CallbackContext ctx)
    {
        anim.SetBool("isIdle", false);
        if (IsGround())
        {
            anim.SetBool("isJumping", true);
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            jumpCounter = jumpTime;
        }
        else if (jumpCounter > 0) //double jump
        {
            //reset velocity 
            rb.velocity = Vector3.zero;
            //
            anim.SetBool("isJumping", true);
            rb.velocity += new Vector3(0f, jumpForce, 0f);
            jumpCounter--;
        }
    }
    #endregion


    // private void OnDisable()
    // {
    //     
    //     inputSystem.Player.Jump.performed -= Jump;
    //     inputSystem.Disable();
    // }
}
