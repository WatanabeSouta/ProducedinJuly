using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // サウンドを再生
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
