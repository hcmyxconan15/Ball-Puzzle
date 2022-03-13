using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] Text pointText;
   [SerializeField] int currentScore = 0;
   [SerializeField] int pointBlockDestroy = 0;

    private void Awake() {
        pointText.text = currentScore.ToString();
    }
    public void AddScore()
    {
        currentScore += pointBlockDestroy;
        pointText.text = currentScore.ToString();
    }
}
