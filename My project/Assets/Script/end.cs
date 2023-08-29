using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    public GameObject player;
    public Transform bg;

    // Start is called before the first frame update
    void Start()
    {
        bg = transform.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            bg.gameObject.SetActive(true);
            //this.gameObject.SetActive(false);
        }

    }
}
