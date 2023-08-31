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

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAngle();
        ShootBullet();
        transform.position = transform.position + transform.up * Time.deltaTime * speedModifier;
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

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.eulerAngles = Vector3.forward * leftup;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = Vector3.forward * leftdown;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * left;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.eulerAngles = Vector3.forward * rightup;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = Vector3.forward * rightdown;
            }
            else
            {
                transform.eulerAngles = Vector3.forward * right;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = Vector3.forward * up;
        }
        else if (Input.GetKey(KeyCode.S))
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
            Instantiate(Next_tier, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
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
