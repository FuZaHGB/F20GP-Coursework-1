using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfighter_Controller : MonoBehaviour
{
    public float roll = 20f;
    public float yaw = 20f;
    public float pitch = 20f;
    public float regSpeed = 20f;
    public float boostSpeed = 30f;
    public float currentSpeed = 0f;
    public float acceleration = 1f;
    public float deceleration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (currentSpeed < regSpeed)
            {
                currentSpeed += acceleration;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (currentSpeed > -regSpeed)
            {
                currentSpeed -= deceleration;
                transform.Translate(0, Time.deltaTime * -currentSpeed, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.right, pitch * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.left, pitch * Time.deltaTime);
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate
        //}
    }
}
