using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void StartGame()
    {
        AudioSource.PlayClipAtPoint(clip, this.transform.position, 1f);
        PlayerController.score = 0;
        SceneManager.LoadScene("Scene_Base");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
