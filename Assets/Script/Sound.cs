using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();

        // �T�E���h���Đ�
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
