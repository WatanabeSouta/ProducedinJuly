using UnityEngine;

public class YukaSound : MonoBehaviour
{
    public AudioClip impactSound; // サウンドファイルを指定
    private AudioSource audioSource; // AudioSourceコンポーネント

    void Start()
    {
        // AudioSourceコンポーネントを追加
        audioSource = gameObject.AddComponent<AudioSource>();

        // サウンドファイルが指定されているか確認
        if (impactSound == null)
        {
            Debug.LogError("Impact sound is not assigned.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Groundタグを持つオブジェクトと衝突したとき
        if (collision.gameObject.CompareTag("Ground"))
        {
            // サウンドを再生
            if (audioSource != null && impactSound != null)
            {
                audioSource.PlayOneShot(impactSound);
            }
            else
            {
                Debug.LogWarning("AudioSource or impactSound is not set up correctly.");
            }
        }
    }
}
