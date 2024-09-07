using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject player; // ここにプレイヤーオブジェクトを割り当てる
    public float speed = 2.0f; // モンスターの移動速度

    private void Start()
    {
        // playerが割り当てられていなければ、自動で探して設定
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // プレイヤーの位置を取得
            Vector3 playerPosition = player.transform.position;

            // モンスターの位置を取得
            Vector3 monsterPosition = transform.position;

            // プレイヤーに向かって移動するためのベクトルを計算
            Vector3 direction = (playerPosition - monsterPosition).normalized;

            // Rigidbody2Dコンポーネントを取得
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // プレイヤーの方向に移動
                rb.velocity = direction * speed;
            }
        }
        else
        {
            // playerがnullの場合、速度をゼロにする
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
