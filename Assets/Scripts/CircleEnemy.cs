using UnityEngine;

public class CircleEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveSpeed = 7.5f;   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
