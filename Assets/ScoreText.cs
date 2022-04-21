using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        UpdateScore(0);
    }
    public void UpdateScore(int score)
    {
        text.text = $"x {score.ToString()}";
    }
}
