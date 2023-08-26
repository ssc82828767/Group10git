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
    public Image HPbar, HPbar_BG;
    public Text indicator;
    public float hp, maxhp;
    public GameObject player;
    private int index; 

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerController.score;
    }

    // Update is called once per frame
    void Update()
    {
        HPstats();
        HP_bar_length();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerController.score;
    }

    // hp bar display
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
            maxhp = player.GetComponent<Health>().maxhp;
            hp = player.GetComponent<Health>().hp;
        }
    }

    // more max health, longer the health bar
    private void HP_bar_length()
    {
        if (player != null)
        {
            index = player.GetComponent<PlayerController>().tier;
            indicator.text = index.ToString();
        }
        if (index ==1)
        {
            HPbar.transform.localScale = new Vector2(1f, 1f);
            HPbar_BG.transform.localScale = new Vector2(1f, 1f);
        }
        if (index == 2)
        {
            HPbar.transform.localScale = new Vector2(1.5f, 1f);
            HPbar_BG.transform.localScale = new Vector2(1.5f, 1f);
        }
        if (index == 3)
        {
            HPbar.transform.localScale = new Vector2(2f, 1f);
            HPbar_BG.transform.localScale = new Vector2(2f, 1f);
        }
        if (index == 4)
        {
            HPbar.transform.localScale = new Vector2(2.5f, 1f);
            HPbar_BG.transform.localScale = new Vector2(2.5f, 1f);
        }
    }
}
