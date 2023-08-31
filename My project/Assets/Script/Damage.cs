using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int value = 1;
    public string[] unaffectedTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Array.IndexOf(unaffectedTags, other.gameObject.tag) < 0)
        {
            other.gameObject.GetComponent<Health>().ReduceHP(value);
        }
    }
}
