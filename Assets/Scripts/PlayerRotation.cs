using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    void Update()
    {
        Vector3 direction = cameraTransform.forward;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
