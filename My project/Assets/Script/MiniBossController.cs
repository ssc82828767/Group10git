using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossController : MonoBehaviour
{
    public int bulletSpeed = 30;
    public GameObject bullet;
    public float bulletCooldown = 3f;
    public float bulletClusterCooldown = 1f;

    private float bulletCooldownCurrent = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBullet();
    }

    void CheckBullet()
    {
        bulletCooldownCurrent += Time.deltaTime;
        if (bulletCooldownCurrent >= bulletCooldown)
        {
            //In Bosconian the space stations shoot 1-3 bullets, I'll have it just shoot 3 in an interval.
            //DOESNT WORK, SHOOTS CONSTANTLY
            //InvokeRepeating("ShootBullet", 5, 3);
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
        bulletCooldownCurrent = 0.0f;

    }
}
