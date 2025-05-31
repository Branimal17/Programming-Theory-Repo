using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null) return;

        if (collision.gameObject == null) return;

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ceiling"))
        {
            Destroy(gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.livesRemaining--;
            }
        }
    }

}

