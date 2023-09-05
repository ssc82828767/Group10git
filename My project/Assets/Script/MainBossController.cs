using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MainBossController : MonoBehaviour
{
    public int miniBossCount = 3;
    public GameObject forceField;
    public float attackDuration = 4f;
    public float restDuration = 5f;

    public GameObject bullet;
    public int bulletSpeed = 30;
    public float bulletCooldown = 1f;

    public Sprite ReducedForceField1;
    public Sprite ReducedForceField2;

    private int miniBossesDestroyed = 0;
    private GameObject forceFieldRef;
    private bool spinning = true;
    private float bulletCooldownCurrent = 0f;
    private bool hasForceField = true;

    // Start is called before the first frame update
    void Start()
    {
        forceFieldRef = Instantiate(forceField, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (forceFieldRef == null && spinning) 
        {
            RotateAwayFrom(GameObject.FindWithTag("Player"));
            bulletCooldownCurrent += Time.deltaTime;
            if (bulletCooldownCurrent >= bulletCooldown)
            {
                ShootInCircle();
                bulletCooldownCurrent = 0;
            }
        }
    }

    public void NotifyMiniBossDestroyed()
    {
        miniBossesDestroyed += 1;
        if(miniBossesDestroyed >= miniBossCount)
        {
            Destroy(forceFieldRef);
            hasForceField = false;
            Invoke(nameof(StopStartSpinning), restDuration);
        }
        if (miniBossesDestroyed == 1)
        {
            forceFieldRef.GetComponent<SpriteRenderer>().sprite = ReducedForceField1;
        }
        else if (miniBossesDestroyed == 2)
        {
            forceFieldRef.GetComponent<SpriteRenderer>().sprite = ReducedForceField2;
        }
    }

    void StopStartSpinning()
    {
        spinning = !spinning;
        if (spinning)
        {
            Invoke(nameof(StopStartSpinning), attackDuration);
        }
        else
        {
            Invoke(nameof(StopStartSpinning), restDuration);
        }
    }

    void ShootInCircle()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        GameObject bulletInstance2 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
        GameObject bulletInstance3 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(90, Vector3.forward));
        GameObject bulletInstance4 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-90, Vector3.forward));
        GameObject bulletInstance5 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(135, Vector3.forward));
        GameObject bulletInstance6 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(45, Vector3.forward));
        GameObject bulletInstance7 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-45, Vector3.forward));
        GameObject bulletInstance8 = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(-135, Vector3.forward));

        bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance2.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance3.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance4.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance5.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance6.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance7.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance8.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
    }

    void RotateAwayFrom(GameObject target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float angle = Vector3.Angle(Vector3.up, directionToTarget);
        if (target.transform.position.x > transform.position.x) angle *= -1;
        Quaternion towardsRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion awayRotation = towardsRotation * Quaternion.AngleAxis(180, Vector3.right);

        // Rotate the game object.
        transform.rotation = Quaternion.Slerp(transform.rotation, awayRotation, Time.deltaTime);
    }

    public bool HasForceField()
    {
        return hasForceField;
    }
}
