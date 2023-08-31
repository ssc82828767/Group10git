using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 1;
    public int maxhp;

    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp;
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
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
        showDamage();
    }

    private void showDamage()
    {
        setSpriteColorRed();
        Invoke(nameof(setSpriteColorWhite), .1f);
        Invoke(nameof(setSpriteColorRed), .2f);
        Invoke(nameof(setSpriteColorWhite), .3f);
    }

    private void setSpriteColorRed()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void setSpriteColorWhite()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
