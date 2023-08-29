using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletController_homing : MonoBehaviour
{
    public int bulletSpeed = 100;
    public int lifespan = 5;
    public int bulletDamage = 1;
    public string[] unaffectedTags;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        player = null;
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, bulletSpeed * Time.deltaTime);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        Debug.Log(other.gameObject.name);
        if(Array.IndexOf(unaffectedTags, other.gameObject.tag) < 0)
        {
            other.gameObject.GetComponent<Health>().ReduceHP(bulletDamage);
            Destroy(gameObject);
        }
    }
}
