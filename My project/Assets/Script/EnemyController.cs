using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public int speedModifier = 8;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //if (player == null)
           // player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = null;
        if (player == null)
            player = GameObject.FindWithTag("Player");

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedModifier * Time.deltaTime);

    }
}
