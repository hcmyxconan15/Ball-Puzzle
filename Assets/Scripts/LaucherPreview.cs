using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaucherPreview : MonoBehaviour
{
    LineRenderer lineRenderer;
    Vector3 dragStartPoint;
    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPoint = worldPoint;
        lineRenderer.SetPosition(0,dragStartPoint);
    }
    public void SetEndPoint(Vector3 wordPoint)
    {
        Vector3 pointOffset = wordPoint - dragStartPoint;
        Vector3 endPoint = transform.position + pointOffset;
        lineRenderer.SetPosition(1, endPoint);
    }
}
