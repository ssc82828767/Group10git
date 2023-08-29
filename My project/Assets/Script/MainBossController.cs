using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBossController : MonoBehaviour
{
    public int miniBossCount = 3;
    public GameObject forceField;

    private int miniBossesDestroyed = 0;

    private GameObject forceFieldRef;

    // Start is called before the first frame update
    void Start()
    {
        forceFieldRef = Instantiate(forceField, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NotifyMiniBossDestroyed()
    {
        miniBossesDestroyed += 1;
        if(miniBossesDestroyed >= miniBossCount)
        {
            Destroy(forceFieldRef);
        }
    }
}
