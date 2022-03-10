using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallLaucher ballLaucher;
    private void Awake() {
         ballLaucher = FindObjectOfType<BallLaucher>();
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        ballLaucher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
        Debug.Log(ballLaucher.balls.Count);
    }
}
