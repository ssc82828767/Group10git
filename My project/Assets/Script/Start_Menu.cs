using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Start_Menu : MonoBehaviour
{
    public AudioClip clip;
    public Transform guide;
    public float timer = 5.0f;
    public bool start;

    //loading bar
    public Image loading_bar;
    private float progress = 0;
    private float duration = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        guide = transform.Find("guide");
    }

    public void StartGame()
    {
        AudioSource.PlayClipAtPoint(clip, this.transform.position, 1f);
        PlayerController.score = 0;
        guide.gameObject.SetActive(true);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            ProgressBar();
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                start = false;
                timer = 5.0f;
                SceneManager.LoadScene("Scene_Base");
            }
        }
    }

    private void ProgressBar()
    {
        progress += Time.deltaTime;
        loading_bar.fillAmount = progress / duration;
        if (progress >= duration)
        {
           loading_bar.fillAmount = 1;
        }
    }
}
