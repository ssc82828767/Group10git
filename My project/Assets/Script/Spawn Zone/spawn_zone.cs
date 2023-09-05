using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawn_zone : MonoBehaviour
{
    public float xSize, ySize, zSize;
    private float spawnCD = 3f;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    private GameObject player;
    public Vector3 offsetPos;


    private GameObject enemy;
    private int enemy_index;
    public int tier_indicator;
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
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {   //make the spawn zones follow player movement
            Vector3 Position = player.transform.position;

            Position.x += offsetPos.x;
            Position.y += offsetPos.y;
            Position.z = 0;

            transform.position = new Vector3(Position.x, Position.y, Position.z);

            //change the spawn rules depending on player tiers
            tier_indicator = player.GetComponent<PlayerController>().tier;
            if (tier_indicator == 1)
            {
                spawn_1();
            }
            else if (tier_indicator == 2)
            {
                spawn_2();
            }
            else if (tier_indicator == 3)
            {
                spawn_3();
            }
            else if (tier_indicator == 4)
            {
                spawn_4();
            }

        }
    }

    private void spawn_1()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            enemy_index = Random.Range(1, 101);
            if (enemy_index <= 5)
            {
                enemy = enemy0;
            }
            else if (enemy_index >= 6 && enemy_index <= 50)
            {
                enemy = enemy1;
            }
            else if (enemy_index >= 51 && enemy_index <= 75)
            {
                enemy = enemy2;
            }
            else if (enemy_index >= 76 && enemy_index <= 90)
            {
                enemy = enemy4;
            }
            else if (enemy_index >= 91)
            {
                enemy = enemy5;
            }

            Instantiate(enemy, new Vector3(
                Random.Range(-xSize / 2, xSize / 2) + transform.position.x,
                Random.Range(-ySize / 2, ySize / 2) + transform.position.y,
                0
            ), Quaternion.identity);
            spawnCD = Random.Range(4, 12);
            enemy = null;
        }
    }
    private void spawn_2()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            enemy_index = Random.Range(1, 101);
            if (enemy_index <= 5)
            {
                enemy = enemy0;
            }
            else if (enemy_index >= 6 && enemy_index <= 25)
            {
                enemy = enemy1;
            }
            else if (enemy_index >= 26 && enemy_index <= 45)
            {
                enemy = enemy2;
            }
            else if (enemy_index >= 46 && enemy_index <= 55)
            {
                enemy = enemy3;
            }
            else if (enemy_index >= 56 && enemy_index <= 70)
            {
                enemy = enemy4;
            }
            else if (enemy_index >= 71 && enemy_index <= 85)
            {
                enemy = enemy5;
            }
            else if (enemy_index >= 86 && enemy_index <= 95)
            {
                enemy = enemy6;
            }
            else if (enemy_index >= 96 && enemy_index <= 100)
            {
                enemy = enemy8;
            }

            Instantiate(enemy, new Vector3(
                Random.Range(-xSize / 2, xSize / 2) + transform.position.x,
                Random.Range(-ySize / 2, ySize / 2) + transform.position.y,
                0
            ), Quaternion.identity);
            spawnCD = Random.Range(3, 10);
            enemy = null;
        }
    }
    private void spawn_3()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            enemy_index = Random.Range(1, 101);
            if (enemy_index <= 5)
            {
                enemy = enemy0;
            }
            else if (enemy_index >= 6 && enemy_index <= 15)
            {
                enemy = enemy1;
            }
            else if (enemy_index >= 16 && enemy_index <= 25)
            {
                enemy = enemy2;
            }
            else if (enemy_index >= 26 && enemy_index <= 40)
            {
                enemy = enemy3;
            }
            else if (enemy_index >= 41 && enemy_index <= 55)
            {
                enemy = enemy4;
            }
            else if (enemy_index >= 56 && enemy_index <= 70)
            {
                enemy = enemy5;
            }
            else if (enemy_index >= 71 && enemy_index <= 85)
            {
                enemy = enemy6;
            }
            else if (enemy_index >= 86 && enemy_index <= 95)
            {
                enemy = enemy7;
            }
            else if (enemy_index >= 96 && enemy_index <= 100)
            {
                enemy = enemy8;
            }

            Instantiate(enemy, new Vector3(
                Random.Range(-xSize / 2, xSize / 2) + transform.position.x,
                Random.Range(-ySize / 2, ySize / 2) + transform.position.y,
                0
            ), Quaternion.identity);
            spawnCD = Random.Range(3, 9);
            enemy = null;
        }
    }

    private void spawn_4()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            enemy_index = Random.Range(1, 101);
            if (enemy_index <= 5)
            {
                enemy = enemy0;
            }
            else if (enemy_index >= 6 && enemy_index <= 10)
            {
                enemy = enemy1;
            }
            else if (enemy_index >= 11 && enemy_index <= 15)
            {
                enemy = enemy2;
            }
            else if (enemy_index >= 16 && enemy_index <= 30)
            {
                enemy = enemy3;
            }
            else if (enemy_index >= 31 && enemy_index <= 40)
            {
                enemy = enemy4;
            }
            else if (enemy_index >= 41 && enemy_index <= 55)
            {
                enemy = enemy5;
            }
            else if (enemy_index >= 56 && enemy_index <= 70)
            {
                enemy = enemy6;
            }
            else if (enemy_index >= 71 && enemy_index <= 85)
            {
                enemy = enemy7;
            }
            else if (enemy_index >= 86 && enemy_index <= 90)
            {
                enemy = enemy8;
            }
            else if (enemy_index >= 91 && enemy_index <= 100)
            {
                enemy = enemy9;
            }

            Instantiate(enemy, new Vector3(
                Random.Range(-xSize / 2, xSize / 2) + transform.position.x,
                Random.Range(-ySize / 2, ySize / 2) + transform.position.y,
                0
            ), Quaternion.identity);
            spawnCD = Random.Range(3, 9);
            enemy = null;
        }
    }
}
