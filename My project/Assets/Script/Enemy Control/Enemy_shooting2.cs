using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting2 : MonoBehaviour
{
    public int speedModifier = 8;

    private GameObject player;

    private float bulletPrimaryCooldownCurrent = 0.0f;
    private float bulletSecondaryCooldownCurrent = 0.0f;
    private int bulletsShot = 0;

    public GameObject bullet;
    public int bulletSpeed = 30;
    public float bulletPrimaryCooldown = 5f;
    public float bulletSecondaryCooldown = 1f;
    public int bulletClusterSize = 3;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedModifier * Time.deltaTime);
        }
        CheckBullet();
    }

    void CheckBullet()
    {
        //We use two cooldowns, one for firing a cluster and a second for the space between each bullet in a cluster
        bulletPrimaryCooldownCurrent += Time.deltaTime;
        bulletSecondaryCooldownCurrent += Time.deltaTime;
        if (bulletPrimaryCooldownCurrent >= bulletPrimaryCooldown)
        {
            //In Bosconian the space stations shoot 1-3 bullets, I'll have it just shoot 3 in an interval.
            if (bulletSecondaryCooldownCurrent >= bulletSecondaryCooldown)
            {
                player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    ShootBullet();
                }
                bulletSecondaryCooldownCurrent = 0;
                bulletsShot++;
            }
            if (bulletsShot >= bulletClusterSize)
            {
                bulletsShot = 0;
                bulletPrimaryCooldownCurrent = 0;
            }
        }
    }

    void ShootBullet()
    {
        Vector3 directionToTarget = player.transform.position - transform.position;
        float angle = Vector3.Angle(Vector3.up, directionToTarget);
        if (player.transform.position.x > transform.position.x) angle *= -1;
        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bulletInstance5 = Instantiate(bullet, transform.position, bulletRotation);
        bulletInstance5.GetComponent<BulletController>().bulletSpeed = bulletSpeed;

        GameObject bulletInstance = Instantiate(bullet, transform.position + transform.up * 4 + Vector3.left * 4, transform.rotation * Quaternion.AngleAxis(45, Vector3.forward));
        GameObject bulletInstance3 = Instantiate(bullet, transform.position + transform.up * -4 + Vector3.left * 4, transform.rotation * Quaternion.AngleAxis(135, Vector3.forward));
        GameObject bulletInstance4 = Instantiate(bullet, transform.position + transform.up * -4 + Vector3.left * -4, transform.rotation * Quaternion.AngleAxis(225, Vector3.forward));
        GameObject bulletInstance2 = Instantiate(bullet, transform.position + transform.up * 4 + Vector3.left * -4, transform.rotation * Quaternion.AngleAxis(315, Vector3.forward));
        bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance2.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance3.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletInstance4.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
    }
}
