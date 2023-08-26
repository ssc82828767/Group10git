using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    //for the HP bar
    public Image HPbar;
    public float hp, maxhp;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerController.score;

        //maxhp = GameObject.FindWithTag("Player").GetComponent<Health>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        HPstats();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerController.score;
    }

    // hp bar
    private void HPstats()
    {
        HPbar.fillAmount = hp / maxhp;
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            maxhp = 1;
            hp = 0;
        }
        else
        {
            maxhp = GameObject.FindWithTag("Player").GetComponent<Health>().maxhp;
            hp = player.GetComponent<Health>().hp;
        }
    }
}
