using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public int speedModifier = 8;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedModifier * Time.deltaTime);
        }
    }
}
