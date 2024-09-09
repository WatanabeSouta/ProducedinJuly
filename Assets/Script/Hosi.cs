using UnityEngine;
using System.Collections;

public class Hosi : MonoBehaviour
{
    public float speed = 5f; // モンスターの移動速度

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 左下に移動するベクトル
        Vector2 movement = new Vector2(-1, -1).normalized;
        rb.velocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Wallタグに当たった場合、すぐに消す
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        // GroundタグまたはPlayerタグに当たった場合、1秒後に消す
        else if (collision.gameObject.CompareTag("Ground") ||
                 collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyAfterDelay(0.5f));
        }
    }

    // 指定された時間後にオブジェクトを非表示にするコルーチン
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
