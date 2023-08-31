using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Powerup : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //self destory after taken by player
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
