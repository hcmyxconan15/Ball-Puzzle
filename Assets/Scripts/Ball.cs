using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    private new Rigidbody2D rigidbody2D;
    
    private void Awake() 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized*moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collistion) 
    {
        float angle = Vector2.Angle(Vector2.right, rigidbody2D.velocity);
        if(angle < 1 || angle >=179 && angle <= 180)
        {
            rigidbody2D.velocity = rigidbody2D.velocity + new Vector2(0,2);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<BallLaucher>().CreateBall();
    }
}
