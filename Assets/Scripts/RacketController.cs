using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    public Rigidbody rb;
    public bool isPlayer = true;
    public float offset = 0.2f;

    private Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByComputer();
        }
    }

    private void MoveByPlayer()
    {
        bool pressedUp = Input.GetKey(upKey);
        bool pressedDown = Input.GetKey(downKey);

        if (pressedUp)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (pressedDown)
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void MoveByComputer()
    {
        if (ball.position.z > transform.position.z + offset)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (ball.position.z < transform.position.z - offset)
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
