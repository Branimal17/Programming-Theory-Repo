using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotateSpeed = 1000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.right);
    }
}
