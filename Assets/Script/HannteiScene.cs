using UnityEngine;
using UnityEngine.SceneManagement;

public class HannteiScene : MonoBehaviour
{
    // シーン名を設定します
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが指定したタグを持っているか確認します
        if (collision.gameObject.CompareTag("Player"))
        {
            // シーンを変更します
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
