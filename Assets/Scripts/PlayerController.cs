using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //---------角色设置--------------------
    public float moveSpeed, jumpForce;
    public int jumpTime;
    public Transform groundPoint;
    public Animator anim;
    //------------------------------------
    public Rigidbody rb;
    private float idleX, idleY;
    private Vector2 _moveInput;
    private int jumpCounter;
    private bool jump;
    public LayerMask whatIsGround;
    
    
    void Start()
    {
        init();
    }
    
    
    void Update()
    {
        BasicMovement();
        Jump();
    }

    private void init()
    {
        jumpCounter = jumpTime;
        jump = false;
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
                if (rb.velocity.y > 0)
                {
                    anim.SetBool("isJumping", true);
                    // rb.velocity += new Vector3(0f, jumpForce, 0f);
                    rb.AddForce(transform.up * jumpForce/2,ForceMode.VelocityChange);
                    jumpCounter--;
                }
                else
                {
                    anim.SetBool("isJumping", true);
                    // rb.velocity += new Vector3(0f, jumpForce, 0f);
                    rb.AddForce(transform.up * jumpForce,ForceMode.VelocityChange);
                    jumpCounter--;
                }
            }
        }

        if (IsGround())
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", true);
        }
        
    }


}
