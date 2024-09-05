using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health = 100; // モンスターの初期HP

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
        // モンスターを削除するなどの処理
        Destroy(gameObject); // モンスターを削除
    }
}
