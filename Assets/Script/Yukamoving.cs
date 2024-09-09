using UnityEngine;

public class Yukamoving : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(1, 0, 0);
    public float speed = 2f;
    private bool isPlayerOnPlatform = false;
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isPlayerOnPlatform)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
        transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
        else
        {
            isPlayerOnPlatform = false;
        }
    }
}
