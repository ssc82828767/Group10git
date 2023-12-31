using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossController : MonoBehaviour
{
    public GameObject bullet;
    public int bulletSpeed = 30;
    public float bulletPrimaryCooldown = 5f;
    public float bulletSecondaryCooldown = 1f;
    public int bulletClusterSize = 3;

    public GameObject powerUp;

    public GameObject tether;

    private GameObject player;
    private float bulletPrimaryCooldownCurrent = 0.0f;
    private float bulletSecondaryCooldownCurrent = 0.0f;
    private int bulletsShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletPrimaryCooldownCurrent += Random.Range(-5.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
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

        GameObject bulletInstance = Instantiate(bullet, transform.position, bulletRotation);
        bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
    }

    private void OnDestroy()
    {
        GameObject.Destroy(tether);

        GameObject powerUpInstance = Instantiate(powerUp, transform.position, transform.rotation);

        GameObject.FindWithTag("MainBoss").GetComponent<MainBossController>().NotifyMiniBossDestroyed();
    }
}
