using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoadController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            Destroy(item);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
