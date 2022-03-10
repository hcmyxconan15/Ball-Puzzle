using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaucher : MonoBehaviour
{
    [SerializeField] private Ball ballPrefeb;
    public  List<Ball> balls = new List<Ball>();
    BlockSpawn blockSpawn;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private LaucherPreview laucherPreview;
    private int ballsReady = 1;

    private void Awake()
    {
        blockSpawn = FindObjectOfType<BlockSpawn>();
        laucherPreview = GetComponent<LaucherPreview>();
        CreateBall();
        Debug.Log(balls.Count);
        
        
    }
    public void ReturnBall()
    {
        ballsReady ++;
        if(ballsReady == balls.Count)
        {
          blockSpawn.SpawnRowOfBlocks();
          CreateBall();
        }
    }
    void Update()
    {
        Vector3 wordPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(wordPostion);
        }
        if (Input.GetMouseButton(0))
        {
            ContinueDrag(wordPostion);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }
    private void StartDrag(Vector3 wordPostion)
    {
        startPosition = wordPostion;
        laucherPreview.SetStartPoint(transform.position);
    }
    private void ContinueDrag(Vector3 wordPostion)
    {
        endPosition = wordPostion;
        Vector3 direction = endPosition - startPosition;
        laucherPreview.SetEndPoint(transform.position + direction);
    }
    private void EndDrag()
    {
        StartCoroutine(LaunchBalls());
    }
    private IEnumerator LaunchBalls()
    {
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
        foreach (var ball in balls)
        {
            ball.transform.position = transform.position;
            ball.gameObject.SetActive(true);
            ball.GetComponent<Rigidbody2D>().AddForce(direction);
            yield return new WaitForSeconds (0.1f); 
        }
        ballsReady = 0;
    }
    private void CreateBall()
    {
        Ball ball = Instantiate(ballPrefeb);
        balls.Add(ball);
        ballsReady++;
    }
    
}
