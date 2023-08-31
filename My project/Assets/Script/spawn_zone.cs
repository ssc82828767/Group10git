using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_zone : MonoBehaviour
{
    public float xSize, ySize, zSize;
    private float spawnCD = 3f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
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
            enemy_index = Random.Range(1, 17);
            if (enemy_index <= 5)
            {
                enemy = enemy1;
            }
            else if (enemy_index >= 6 && enemy_index <= 9)
            {
                enemy = enemy2;
            }
            else if (enemy_index >= 10 && enemy_index <= 12)
            {
                enemy = enemy3;
            }
            else if (enemy_index >= 13 && enemy_index <= 15)
            {
                enemy = enemy4;
            }
            else if(enemy_index >= 16)
            {
                enemy = enemy5;
            }

            Instantiate(enemy, new Vector3(
                Random.Range(-xSize / 2, xSize / 2) + transform.position.x,
                Random.Range(-ySize / 2, ySize / 2) + transform.position.y,
                0
            ), Quaternion.identity);
            spawnCD = Random.Range(3, 10);
            enemy = null;
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

            transform.position = new Vector3(Position.x, Position.y, Position.z);
        }
    }
}
