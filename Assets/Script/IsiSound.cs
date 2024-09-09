using UnityEngine;

public class IsiSound : MonoBehaviour
{
    public AudioClip impactSound; // サウンドファイルを指定
    private AudioSource audioSource; // AudioSourceコンポーネント

    void Start()
    {
        // AudioSourceコンポーネントを追加
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // サウンドを再生
            audioSource.PlayOneShot(impactSound);
        }
    }
}
