using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // 弾のダメージ量

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Monster"))
        {
            // 衝突したオブジェクトが「Monster」の場合、ダメージを与えてから弾を削除
            if (other.CompareTag("Monster"))
            {
                Monster monster = other.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.TakeDamage(damage); // モンスターにダメージを与える
                }
            }

            // 衝突したオブジェクトが「Ground」または「Monster」の場合、弾を削除
            Destroy(gameObject); // 弾を削除
        }
    }
}
