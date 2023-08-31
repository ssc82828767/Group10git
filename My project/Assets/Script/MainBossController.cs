using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
        if (forceFieldRef == null ) 
        {
            RotateAwayFrom(GameObject.FindWithTag("Player"));
        }
    }

    public void NotifyMiniBossDestroyed()
    {
        miniBossesDestroyed += 1;
        if(miniBossesDestroyed >= miniBossCount)
        {
            Destroy(forceFieldRef);
        }
    }

    private void RotateAwayFrom(GameObject target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float angle = Vector3.Angle(Vector3.up, directionToTarget);
        if (target.transform.position.x > transform.position.x) angle *= -1;
        Quaternion towardsRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion awayRotation = towardsRotation * Quaternion.AngleAxis(180, Vector3.right);

        // Rotate the game object.
        transform.rotation = Quaternion.Slerp(transform.rotation, awayRotation, Time.deltaTime);
        Debug.Log(Time.deltaTime);
    }
}
