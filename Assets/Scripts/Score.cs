﻿
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform playerTransform;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        int score = GameData.GetCurrentScore();
        scoreText.text = score.ToString();
    }
}
