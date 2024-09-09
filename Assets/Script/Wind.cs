using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windForce = 10f; // 風の強さ

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("プレイヤーが範囲に入りました");

            // 力を加えてプレイヤーを右に動かす
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(10f, 0), ForceMode2D.Impulse); // x方向に力を加える
            }
        }
    }




    private void OnTriggerExit2D(Collider2D other)
    {
        // エリアから出たときの処理（必要であればここに追加）
    }
}
