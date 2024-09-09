using UnityEngine;

public class IsiSound : MonoBehaviour
{
    public AudioClip impactSound; // �T�E���h�t�@�C�����w��
    private AudioSource audioSource; // AudioSource�R���|�[�l���g

    void Start()
    {
        // AudioSource�R���|�[�l���g��ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // �T�E���h���Đ�
            audioSource.PlayOneShot(impactSound);
        }
    }
}
