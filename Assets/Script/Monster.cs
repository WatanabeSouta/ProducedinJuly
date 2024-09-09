using UnityEngine;
using System.Collections;


public class Monster : MonoBehaviour
{
    public int health = 100; // モンスターの初期HP
    public int damage = 10;  // モンスターがプレイヤーに与えるダメージ量
    public AudioClip hitSound; // プレイヤーに衝突したときのサウンド
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // モンスターがダメージを受けるメソッド
    public void TakeDamage(int damage)
    {
        health -= damage; // HPを減らす
        if (health <= 0)
        {
            Die(); // HPが0以下になったら死ぬ
        }
    }

    // モンスターが死ぬ処理
    private void Die()
    {
        Destroy(gameObject); // モンスターを削除
    }

    // プレイヤーや他のタグのオブジェクトに衝突したときの処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがプレイヤーかどうかを確認
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーのHPを減らす処理
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // プレイヤーにダメージを与える
                
                // サウンドを再生してからモンスターを削除
                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound);
                    // サウンド再生が終わるまでモンスターを非表示にして待つ
                    StartCoroutine(DestroyAfterSound());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        // 衝突したオブジェクトが「Ground」タグかどうかを確認
        if (collision.gameObject.CompareTag("Ground"))
        {
            // モンスターを削除
            Destroy(gameObject);
        }

        // 衝突したオブジェクトが「Baria」タグかどうかを確認
        if (collision.gameObject.CompareTag("Baria"))
        {
            // モンスターを削除
            Destroy(gameObject);
        }
    }

    // サウンド再生後にモンスターを削除するコルーチン
    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }
}
