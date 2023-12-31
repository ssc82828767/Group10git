using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int bulletSpeed = 100;
    public int lifespan = 5;


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
        if(other.gameObject.tag == "ForceField")
        {
            Destroy(gameObject);
        }
    }
}
