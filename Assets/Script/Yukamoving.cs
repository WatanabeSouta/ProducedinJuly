using UnityEngine;

public class Yukamoving : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(1, 0, 0); // 方向
    public float speed = 2f; // 移動速度

    private bool isPlayerOnPlatform = false; // プレイヤーが乗っている
    private Vector3 initialPosition; // 初期位置

    void Start()
    {
        // 初期位置
        initialPosition = transform.position;
    }

    void Update()
    {
        //床を移動させる
        if (isPlayerOnPlatform)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }

        //初期位置固定
        transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
    }

    //床に乗ったときに呼ばれる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    //離れたときに呼ばれる
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }
}
