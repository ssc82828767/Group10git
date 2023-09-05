using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static int score = 0;

    public int speedModifier = 10;
    public int bulletSpeed = 30;
    public GameObject bullet;
    public int playerDamage = 10;
    public float bulletCooldown = 0.25f;

    private float bulletCooldownCurrent = 0.0f; 
    private Health health;

    public GameObject Next_tier;
    public int tier;

    private Item_Powerup item1;


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        score = 0;

    }


    // Update is called once per frame
    void Update()
    {
        SetAngle();
        transform.position = transform.position + transform.up * Time.deltaTime * speedModifier;

        //power up the bullets shootting
        if (tier == 1)
        {
            ShootBullet();
        }
        else if (tier == 2)
        {
            ShootBullet2();
        }
        else if (tier == 3)
        {
            ShootBullet3();
        }
        else if (tier == 4)
        {
            ShootBullet4();
        }
    }

    void SetAngle()
    {
        int left = 90;
        int leftup = 45;
        int leftdown = 135;
        int right = -90;
        int rightup = -45;
        int rightdown = -135;
        int up = 0;
        int down = 180;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.eulerAngles = Vector3.forward * leftup;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.eulerAngles = Vector3.forward * leftdown;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * left;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.eulerAngles = Vector3.forward * rightup;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.eulerAngles = Vector3.forward * rightdown;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * right;
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = Vector3.forward * up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = Vector3.forward * down;
        }
    }

    void ShootBullet()
    {
        bulletCooldownCurrent += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && bulletCooldownCurrent >= bulletCooldown)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + transform.up * 4, transform.rotation);
            GameObject bulletInstance2 = Instantiate(bullet, transform.position + transform.up * -4, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance2.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletCooldownCurrent = 0.0f;
            this.GetComponent<AudioSource>().Play();
        }
    }
    void ShootBullet2()
    {
        bulletCooldownCurrent += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && bulletCooldownCurrent >= bulletCooldown)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * 2, transform.rotation);
            GameObject bulletInstance2 = Instantiate(bullet, transform.position + transform.up * -4 + transform.right * 2, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            GameObject bulletInstance3 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * -2, transform.rotation);
            GameObject bulletInstance4 = Instantiate(bullet, transform.position + transform.up * -4 + transform.right * -2, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance2.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance3.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance4.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletCooldownCurrent = 0.0f;
            this.GetComponent<AudioSource>().Play();
        }
    }
    void ShootBullet3()
    {
        bulletCooldownCurrent += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && bulletCooldownCurrent >= bulletCooldown)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * 2, transform.rotation);
            GameObject bulletInstance2 = Instantiate(bullet, transform.position + transform.up * -4 + transform.right * 2, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            GameObject bulletInstance3 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * -2, transform.rotation);
            GameObject bulletInstance4 = Instantiate(bullet, transform.position + transform.up * -4 + transform.right * -2, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            //sideway
            GameObject bulletInstance5 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * -2, transform.rotation * Quaternion.AngleAxis(30, Vector3.forward));
            GameObject bulletInstance6 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * 2, transform.rotation * Quaternion.AngleAxis(-30, Vector3.forward));
            bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance2.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance3.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance4.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance5.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance6.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletCooldownCurrent = 0.0f;
            this.GetComponent<AudioSource>().Play();
        }
    }
    void ShootBullet4()
    {
        bulletCooldownCurrent += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && bulletCooldownCurrent >= bulletCooldown)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * 2, transform.rotation);
            GameObject bulletInstance2 = Instantiate(bullet, transform.position + transform.up * -4 + transform.right * 2, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            GameObject bulletInstance3 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * -2, transform.rotation);
            GameObject bulletInstance4 = Instantiate(bullet, transform.position + transform.up * -4 + transform.right * -2, transform.rotation * Quaternion.AngleAxis(180, Vector3.forward));
            //sideway
            GameObject bulletInstance5 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * -2, transform.rotation * Quaternion.AngleAxis(30, Vector3.forward));
            GameObject bulletInstance6 = Instantiate(bullet, transform.position + transform.up * 4 + transform.right * 2, transform.rotation * Quaternion.AngleAxis(-30, Vector3.forward));
            bulletInstance.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance2.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance3.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance4.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance5.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletInstance6.GetComponent<BulletController>().bulletSpeed = bulletSpeed;
            bulletCooldownCurrent = 0.0f;
            this.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Damage otherDamage = other.gameObject.GetComponent<Damage>();
        //if (otherDamage)
        //{
        //    health.ReduceHP(otherDamage.value);
        //    other.gameObject.GetComponent<Health>().ReduceHP(playerDamage);
        //}

        //power up the ship
        if (other.gameObject.tag == "Item")
        {
            //Instantiate(Next_tier, gameObject.transform.position, Quaternion.identity);
            //Destroy(gameObject);
            item1 = other.GetComponent<Item_Powerup>();
            if (item1 != null)
            {
                Instantiate(Next_tier, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
     if (other.gameObject.tag == "Item")
        {
            //Debug.Log("lvled up");
        }
    }

    private void OnDestroy()
    {
        //SceneManager.LoadScene("Start Menu");
    }

}
