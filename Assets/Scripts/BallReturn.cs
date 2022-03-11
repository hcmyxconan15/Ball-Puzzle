using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallReturn : MonoBehaviour
{
    private BallLaucher ballLaucher;
    private void Awake()
    {
        ballLaucher = FindObjectOfType<BallLaucher>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            if (ballLaucher.isNewLaucherPostion)
            {
                ballLaucher.transform.position = collision.transform.position;
                ballLaucher.isNewLaucherPostion = false;
            }
            ballLaucher.ReturnBall();
            collision.collider.gameObject.SetActive(false);
        }
        if(collision.collider.tag == "Block")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
