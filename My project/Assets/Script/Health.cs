using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHP(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
