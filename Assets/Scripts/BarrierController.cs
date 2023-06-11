using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public float initialMoveSpeed = 5f; 
    public float upperLimit = 1f; 
    public float lowerLimit = -1f; 
    public float speedIncreaseRate = 0.1f; 

    private bool movingUp = true; 
    private float currentMoveSpeed; 

    private void Start()
    {
        currentMoveSpeed = initialMoveSpeed;
        movingUp = (Random.value > 0.5f);
    }

    private void Update()
    {
        currentMoveSpeed += speedIncreaseRate * Time.deltaTime;

        if (movingUp)
        {
            transform.Translate(Vector3.forward * currentMoveSpeed * Time.deltaTime);
            if (transform.position.z >= upperLimit)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * currentMoveSpeed * Time.deltaTime);
            if (transform.position.z <= lowerLimit)
            {
                movingUp = true;
            }
        }
    }
}

