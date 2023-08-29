using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_main : MonoBehaviour
{

    public GameObject player;
    public Vector3 offsetPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            Vector3 Position = player.transform.position;

            Position.x += offsetPos.x;
            Position.y += offsetPos.y;
            Position.z = -10;

            transform.position = Position;
        }
    }
}
