using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController1 : MonoBehaviour
{

    public float speed;
    public float minDirection = 0.5f;
    private Vector3 direction;
    private Rigidbody rb;
    public bool stopped = true;
    public AudioSource soundEffect;

    public GameObject sparksVFX;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
    }

    void fixedUpdate(){
        if (this.stopped){
            return;
        }
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        bool hit = false;

         if (other.CompareTag("Barrier")) {
            soundEffect.Play();
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.y = 0f;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            speed += 0.5f;
            hit = true;

            direction = newDirection;
        }

        if (other.CompareTag("Ball")) {
            soundEffect.Play();
            direction.z = -direction.z;
            speed += 0.5f;
            hit = true;
        }

        if (other.CompareTag("Wall")) {
            soundEffect.Play();
            direction.z = -direction.z;
            speed += 0.5f;
            hit = true;
        }

        if (other.CompareTag("Racket")) {
            soundEffect.Play();
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.y = 0f;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            speed += 0.75f;
            hit = true;

            direction = newDirection;
        }

        if (hit) {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void chooseDirection(){
        
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop() {
        this.stopped = true;
    }

    public void Go() {
        this.speed = 20;
        chooseDirection();
        this.stopped = false;
    }
}

