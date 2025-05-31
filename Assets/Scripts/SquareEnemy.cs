using UnityEngine;

public class SquareEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 2.5f;
        health = 15;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }
}
