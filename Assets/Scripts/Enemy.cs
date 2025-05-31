using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

    private int m_Health = 10;
    protected int Health
    {
        get { return m_Health; }
        set { m_Health = value; }
    }

    private float m_MoveSpeed;
    protected float MoveSpeed { get => m_MoveSpeed; set => m_MoveSpeed = value; }

    public virtual void Move()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);
    }

    public virtual void TakeDamage()
    {
        Health -= 5;
        if (Health <= 0)
        {
            Destroy(gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.score++;
            }
        }
    }
}
