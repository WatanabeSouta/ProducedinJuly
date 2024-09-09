using UnityEngine;

public class Delete : MonoBehaviour
{
    // 衝突時に呼ばれるメソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトのタグが「Delete」の場合
        if (collision.CompareTag("Delete"))
        {
            // このオブジェクトを削除する
            Destroy(gameObject);
        }
    }
}
