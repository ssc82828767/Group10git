using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 1;
    public int maxhp;
    public AudioClip clip;
    public GameObject particle;

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
            AudioSource.PlayClipAtPoint(clip, this.transform.position, 1f);
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation);
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
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) 
        { 
            spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
            Debug.Log(spriteRenderer);
        }
        spriteRenderer.color = Color.red;
    }

    private void setSpriteColorWhite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
        }
        spriteRenderer.color = Color.white;
    }
}
