using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float smoothSpeed = 10f;
    public Vector3 lookAtPointOffset = new Vector3(0, 1.5f, 20f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = new Vector3(1.47f, 2.8f, -2.4f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        Vector3 lookAtPoint = player.transform.position + lookAtPointOffset;
        transform.LookAt(lookAtPoint);
    }
}
