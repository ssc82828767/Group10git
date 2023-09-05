using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public GameObject player;
    public GameObject finalboss;
    public Transform bg;
    public Transform win;
    public AudioClip clip_lose;
    public AudioClip clip_win;

    // Start is called before the first frame update
    void Start()
    {
        bg = transform.Find("Canvas");
        win = transform.Find("winpage");
    }

    // Update is called once per frame
    void Update()
    {
        //game over
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            bg.gameObject.SetActive(true);
            Time.timeScale = 0f;
            AudioSource.PlayClipAtPoint(clip_lose, this.transform.position, 1f);
        }

        //winning
        finalboss = GameObject.FindWithTag("MainBoss");
        if (finalboss == null)
        {
            win.gameObject.SetActive(true);
            Time.timeScale = 0f;
            AudioSource.PlayClipAtPoint(clip_win, this.transform.position, 1f);
        }


    }

    public void return_menu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
