using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    //public float minDirection = 0.5f;

    private bool stopped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* 
    // CODE SNIPPET FOR RACKET DIRECTION CHANGE
    Vector3 newDirection = (transform.position - other.transform.position).normalized;

    newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
    newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

    direction = newDirection;
    */

    public void Stop() {
        stopped = true;
    }

    public void Go() {
        stopped = false;
    }

}
