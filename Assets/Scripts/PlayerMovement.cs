using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float jumpForce = 12;
    public float movementSpeed = 5;
    private float horizontalInput;
    private float verticalInput;
    public bool isGrounded = true;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundCheck;

    private Rigidbody rb;
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Get camera's forward and right, flattened to the ground
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        // Combine input with camera directions
        Vector3 moveDirection = camForward * verticalInput + camRight * horizontalInput;

        // Move in world space
        transform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.World);



        // Animation speed
        float speed = moveDirection.magnitude;
        animator.SetFloat("Speed_f", speed, 0.1f, Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        animator.SetBool("Grounded", isGrounded);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void OnDrawGizmosSelected()
    {
       
    }


    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        animator.SetTrigger("Jump_trig");
    }
   

}
