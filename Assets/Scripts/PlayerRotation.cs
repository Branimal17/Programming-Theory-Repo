using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float mouseSensitivity = 3f;
    public Transform player; // Root object (what turns left/right)
    public Transform cameraTarget; // The "Follow" target used by Cinemachine

    float verticalAngle = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player horizontally
        player.Rotate(Vector3.up * mouseX);

        // Clamp vertical camera angle
        verticalAngle -= mouseY;
        verticalAngle = Mathf.Clamp(verticalAngle, -45f, 75f);

        // Apply vertical rotation to camera target (Cinemachine follows this)
        cameraTarget.localRotation = Quaternion.Euler(verticalAngle, 0f, 0f);
    }
}
