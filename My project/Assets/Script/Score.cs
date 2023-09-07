using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public int score = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        PlayerController.score += score;
        ScoreText scoreText = GameObject.Find("Canvas").GetComponent<ScoreText>();
        if (scoreText != null )
        {
            scoreText.UpdateScore();
        }
    }
}
