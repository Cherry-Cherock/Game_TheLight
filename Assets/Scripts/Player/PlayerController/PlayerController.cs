using System;
using System.Collections;
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
    private BoxCollider MapPlayerStartPoint;
    public Rigidbody rb;
    private float idleX, idleY;
    private Vector2 _moveInput;
    public int jumpCounter;
    private bool jump;
    public LayerMask whatIsGround;

    private void Awake()
    {
        inputSystem = InputManager.inputActions;
        MapPlayerStartPoint = UnityHelper.GetTheChildNodeComponetScripts<BoxCollider>(gameObject, "Start");
        // foreach (var p in ConfigManager.PlayerConfigList)
        // {
        //     moveSpeed = p.Value.MoveSpeed;
        //     jumpForce = p.Value.JumpForce;
        //     jumpTime = p.Value.JumpTime;
        // }
    }

    private void OnEnable()
    {
        init();
        MyAStar.startPoint += OpenMapStartPoint;
    }


    void Update()
    {
        if (IsGround())
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", true);
            jumpCounter = jumpTime;
        }
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isIdle", false);
        }
        BasicMovement();
    }

    private void init()
    {
        inputSystem.Enable();
        jumpCounter = jumpTime;
        jump = false;
        inputSystem.Player.Jump.started += Jump;
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
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGround() && jumpCounter<=0) return;
        if (jumpCounter == 0) StartCoroutine(WaitForLanding());
        
        jumpCounter--;
    
        rb.velocity += new Vector3(0f, rb.velocity.y <= 0 ? jumpForce+Math.Abs(rb.velocity.y):jumpForce-rb.velocity.y, 0f);
        
        Debug.Log("tiao");
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGround());
        yield return new WaitUntil(IsGround);
        
    }
    #endregion

    public void OpenMapStartPoint()
    {
        MapPlayerStartPoint.enabled =true;
    }

    // private void OnDisable()
    // {
    //     
    //     inputSystem.Player.Jump.performed -= Jump;
    //     inputSystem.Disable();
    // }
}
