using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int bulletSpeed = 100;
    public int lifespan = 5;
    public int bulletDamage = 1;
    public string[] unaffectedTags;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.up * Time.deltaTime * bulletSpeed;
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
