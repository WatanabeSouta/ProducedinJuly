using UnityEngine;

public class Yukamoving : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(1, 0, 0); // 移動方向
    public float speed = 2f; // 移動速度

    private bool isPlayerOnPlatform = false; // プレイヤーが乗っているかのフラグ

    void Update()
    {
        // プレイヤーが乗っている間、床を移動させる
        if (isPlayerOnPlatform)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    // プレイヤーが床に乗ったときに呼ばれる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            // プレイヤーを床の子オブジェクトにしない
        }
    }

    // プレイヤーが床から離れたときに呼ばれる
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            // プレイヤーを床の子オブジェクトから解除しない
        }
    }
}
