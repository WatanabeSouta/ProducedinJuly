using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UIを使うための名前空間

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; // ゲームオーバーのテキストオブジェクト
    public AudioClip gameOverSound; // ゲームオーバーのサウンド
    public string sceneToLoad; // 変更したいシーンの名前
    private AudioSource audioSource; // サウンドを再生するためのコンポーネント

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // ゲームオーバーのテキストを初期状態で非表示にする
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトのタグが「Player」か確認する
        if (collision.CompareTag("Player"))
        {
            // プレイヤーオブジェクトを削除する
            Destroy(collision.gameObject);

            // ゲームオーバーのサウンドを再生する
            if (gameOverSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(gameOverSound);
            }

            // 3秒後にゲームオーバーのテキストを表示する
            Invoke("ShowGameOverText", 2f);

            // 6秒後にシーンを変更する
            Invoke("ChangeScene", 5f); // テキストが表示されてから3秒後にシーン変更
        }
    }

    void ShowGameOverText()
    {
        // ゲームオーバーのテキストを表示する
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }

    void ChangeScene()
    {
        // 指定したシーンを読み込む
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
