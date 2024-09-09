using UnityEngine;

public class YukaSound : MonoBehaviour
{
    public AudioClip impactSound; // �T�E���h�t�@�C�����w��
    private AudioSource audioSource; // AudioSource�R���|�[�l���g

    void Start()
    {
        // AudioSource�R���|�[�l���g��ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();

        // �T�E���h�t�@�C�����w�肳��Ă��邩�m�F
        if (impactSound == null)
        {
            Debug.LogError("Impact sound is not assigned.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground�^�O�����I�u�W�F�N�g�ƏՓ˂����Ƃ�
        if (collision.gameObject.CompareTag("Ground"))
        {
            // �T�E���h���Đ�
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
