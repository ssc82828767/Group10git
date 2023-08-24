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
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedModifier * Time.deltaTime);
    }
}
