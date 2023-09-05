using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health : MonoBehaviour
{
    private Health health;
    public int index;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        index = 2;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //self destory after taken by player
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
            health = other.GetComponent<Health>();
            health.hp = health.maxhp;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
