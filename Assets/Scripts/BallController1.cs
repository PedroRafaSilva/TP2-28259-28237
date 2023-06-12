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
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (!stopped)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("Barrier"))
        {
            soundEffect.Play();
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.y = 0f;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), minDirection);
            speed += 0.5f;
            hit = true;

            direction = newDirection;
        }

        if (other.CompareTag("Ball") || other.CompareTag("Wall"))
        {
            soundEffect.Play();
            direction.z = -direction.z;
            speed += 0.5f;
            hit = true;
        }

        if (other.CompareTag("Racket"))
        {
            soundEffect.Play();
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.y = 0f;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), minDirection);
            speed += 0.75f;
            hit = true;

            direction = newDirection;
        }

        if (hit)
        {
            GameObject sparks = Instantiate(sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));

        direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        speed = 20;
        ChooseDirection();
        stopped = false;
    }
}
