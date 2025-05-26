using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    private float horizontalInput;
    private float verticalInput;
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(move * movementSpeed * Time.deltaTime, Space.Self);

        // Calculate speed (0 = idle, 1 = max input)
        float speed = move.magnitude;

        // Update Blend Tree parameter (add smoothing if needed)
        animator.SetFloat("Speed_f", speed, 0.1f, Time.deltaTime);
    }
}
