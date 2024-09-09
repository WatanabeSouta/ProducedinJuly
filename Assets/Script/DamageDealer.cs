using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;  // 与えるダメージ量

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーのHealthスクリプトを取得
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);  // ダメージを与える
            }
        }
    }
}
