using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_zone_east : MonoBehaviour
{
    public float xSize, ySize, zSize;
    private float spawnCD = 3f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    private GameObject player;
    public Vector3 offsetPos;

    private GameObject enemy;
    private int enemy_index;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Vector4(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position,
            new Vector3(xSize, ySize, zSize));
    }

    // Update is called once per frame
    void Update()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            enemy_index = Random.Range(1, 4);
            if (enemy_index == 1)
            {
                enemy = enemy1;
            }
            else if (enemy_index == 2)
            {
                enemy = enemy2;
            }
            else if (enemy_index == 3)
            {
                enemy = enemy3;
            }

            Instantiate(enemy, new Vector3(
                Random.Range(-xSize / 2, xSize / 2) + transform.position.x,
                Random.Range(-ySize / 2, ySize / 2) + transform.position.y,
                0
            ), Quaternion.identity);
            spawnCD = Random.Range(2, 6);
            //enemy = null;
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            Vector3 Position = player.transform.position;

            Position.x += offsetPos.x;
            Position.y += offsetPos.y;
            Position.z = 0;

            transform.position = new Vector3(Position.x + 100, Position.y, Position.z);
        }
    }
}
