using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    public Text scoreText2;
    public Text scoreText3;

    //for the HP bar
    public Image HPbar, HPbar_BG;
    public Text indicator;
    public float hp, maxhp;
    public GameObject player;

    public Image BossHPBar, BossHPBar_BG;
    public Text bossText;

    private GameObject mainBoss;
    private float fBossHP, fBossMaxHP;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerController.score;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        HPstats();
        HP_bar_length();
        scoreText2.text = scoreText.text;
        scoreText3.text = scoreText.text;
    }

    public void UpdateScore()
    {
        player = GameObject.FindWithTag("Player");
        
        scoreText.text = "Score: " + PlayerController.score;
    }

    // hp bar display
    private void HPstats()
    {
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
        HPbar.fillAmount = hp / maxhp;

        mainBoss = GameObject.FindWithTag("MainBoss");
        if (mainBoss == null)
        {
            fBossMaxHP = 1;
            fBossHP = 0;
            BossHPBar.fillAmount = 0;
            BossHPBar_BG.fillAmount = 0;
            bossText.text = "";
        }
        else if (mainBoss.GetComponent<MainBossController>().HasForceField())
        {
            BossHPBar.fillAmount = 0;
            BossHPBar_BG.fillAmount = 0;
            bossText.text = "";
        }
        else
        {
            bossText.text = "BOSS";
            fBossMaxHP = mainBoss.GetComponentsInChildren<Health>()[0].maxhp;
            fBossHP = mainBoss.GetComponentsInChildren<Health>()[0].hp;
            BossHPBar.fillAmount = fBossHP / fBossMaxHP;
            BossHPBar_BG.fillAmount = 1;
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
