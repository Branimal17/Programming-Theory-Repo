using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    protected int health = 10;
    protected float moveSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }

    public virtual void TakeDamage()
    {
        health -= 5;
        if (health <= 0)
        {
            Destroy(gameObject);
            if (GameManager.instance != null)
            {
                GameManager.instance.score++;
            }
        }
    }
}
