using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PolygonCollider2D playerCollider;
    public int speedModifier = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAngle();
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
}
