using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    // 衝突時にシーンを遷移させるターゲットのタグ
    public string targetTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトが指定したタグのものかどうかをチェック
        if (other.CompareTag(targetTag))
        {
            // 遷移するシーンの名前（シーンのビルド設定で設定された名前）
            string sceneName = "ClearScene"; // 遷移先のシーン名に変更

            // シーンを遷移
            SceneManager.LoadScene(sceneName);
        }
    }
}
