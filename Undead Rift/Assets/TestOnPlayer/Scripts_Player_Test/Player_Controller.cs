using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public bool CanMove {get; private set;} = true;
    private bool IsSprinting => canSprint && Input.GetKey(sprintKey);
    private bool ShouldJump => Input.GetKeyDown(jumpKey) && characterController.isGrounded;

    [Header("Functional Options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canJump = true;

    [Header("Functional Options")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintSpeed = 6.0f;
    [SerializeField] private float gravity = 30.0f;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;

    [Header("Jumping Parameters")]
    [SerializeField] private float jumpForce = 8.0f;

    private Camera playerCamera;
    private CharacterController characterController;
    private Animator animator;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(CanMove)
        {
            HandleMovementInput();
            HandleMouseLook();
            if(canJump)
            {
                HandleJump();
            }
            HandleAnimation();

            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void HandleJump()
    {
        if(ShouldJump)
        {
            moveDirection.y = jumpForce;
        }
    }

    private void HandleAnimation()
    {
        bool isRunning = animator.GetBool("IsRunning");
        bool isWalking = animator.GetBool("IsWalking");
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        
        if(!isWalking && forwardPressed)
        {
            animator.SetBool("IsWalking", true);
        }
        if(isWalking && !forwardPressed)
        {
            animator.SetBool("IsWalking", false);
        }
        if(!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool("IsRunning", true);
        }
        if(isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool("IsRunning", false);
        }
        if(ShouldJump)
        {
            animator.SetBool("IsJumping", true);
        }
        if(!ShouldJump)
        {
            animator.SetBool("IsJumping", false);
        }
    }
    
    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }

}
