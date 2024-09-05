using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player; // プレイヤーのTransformを設定
    public float moveSpeed = 2f; // モンスターの移動速度

    private void Update()
    {
        // プレイヤーまでの距離を計算
        float distance = Vector2.Distance(transform.position, player.position);

        // プレイヤーが指定した距離以内にいる場合
        if (distance < 10f) // ここで距離の範囲を設定
        {
            // プレイヤーの方に向かって移動
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
