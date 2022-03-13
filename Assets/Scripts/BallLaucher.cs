using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaucher : MonoBehaviour
{
    [SerializeField] private Ball ballPrefeb;
    public List<Ball> balls = new List<Ball>();
    public bool isNewLaucherPostion; // có ball nào đầu tiên va chạm với Ballreturn hay chưa=
    private BlockSpawn blockSpawn;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private LaucherPreview laucherPreview;
    private int ballsReady = 1;
    private bool isBallMove; // khóa player khi bóng đang di chuyển
    private void Awake()
    {
        blockSpawn = FindObjectOfType<BlockSpawn>();
        laucherPreview = GetComponent<LaucherPreview>();
        isBallMove = true;
        isNewLaucherPostion = true;
        CreateBall();
    }
    public void ReturnBall()
    {
        ballsReady++;
        if (ballsReady == balls.Count)
        {
            blockSpawn.SpawnRowOfBlocks();
            isBallMove = true;
            isNewLaucherPostion = true;
        }
    }
    void Update()
    {
        if (isBallMove)
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
        laucherPreview.SetContinuePreview();
        isBallMove = false;
        ballsReady = 0;
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
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void CreateBall()
    {
        Ball ball = Instantiate(ballPrefeb);
        balls.Add(ball);
        ballsReady++;
    }

}
