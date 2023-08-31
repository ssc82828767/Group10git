using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void StartGame()
    {
        PlayerController.score = 0;
        SceneManager.LoadScene("Scene_Base");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
