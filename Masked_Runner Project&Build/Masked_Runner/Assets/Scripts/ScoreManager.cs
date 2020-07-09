using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score.ToString();
    }

    public void AddPoint(int point)
    {
        score += point;
    }

    public void ResetScore()
    {
        score *= 0;
    }
}
