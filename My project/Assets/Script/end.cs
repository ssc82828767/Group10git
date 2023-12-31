using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public GameObject player;
    public GameObject finalboss;
    public Transform bg;
    public Transform win;
    public AudioClip clip_lose;
    public AudioClip clip_win;
    private bool audio_trigger = false;

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
            if (!audio_trigger)
            {
                AudioSource.PlayClipAtPoint(clip_lose, this.transform.position, 1f);
                audio_trigger = true;
            }
        }
        else
        {
            Time.timeScale = 1.0f;
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
    public void play_again()
    {
        SceneManager.LoadScene("Scene_Base");
    }
}
