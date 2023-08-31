using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().addScore(score);
        GameObject.Find("Canvas").GetComponent<ScoreText>().UpdateScore();
    }
}
