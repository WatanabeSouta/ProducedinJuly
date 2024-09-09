using UnityEngine;
using System.Collections;


public class Monster : MonoBehaviour
{
    public int health = 100; // �����X�^�[�̏���HP
    public int damage = 10;  // �����X�^�[���v���C���[�ɗ^����_���[�W��
    public AudioClip hitSound; // �v���C���[�ɏՓ˂����Ƃ��̃T�E���h
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // �����X�^�[���_���[�W���󂯂郁�\�b�h
    public void TakeDamage(int damage)
    {
        health -= damage; // HP�����炷
        if (health <= 0)
        {
            Die(); // HP��0�ȉ��ɂȂ����玀��
        }
    }

    // �����X�^�[�����ʏ���
    private void Die()
    {
        Destroy(gameObject); // �����X�^�[���폜
    }

    // �v���C���[�⑼�̃^�O�̃I�u�W�F�N�g�ɏՓ˂����Ƃ��̏���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[���ǂ������m�F
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[��HP�����炷����
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // �v���C���[�Ƀ_���[�W��^����
                
                // �T�E���h���Đ����Ă��烂���X�^�[���폜
                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound);
                    // �T�E���h�Đ����I���܂Ń����X�^�[���\���ɂ��đ҂�
                    StartCoroutine(DestroyAfterSound());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        // �Փ˂����I�u�W�F�N�g���uGround�v�^�O���ǂ������m�F
        if (collision.gameObject.CompareTag("Ground"))
        {
            // �����X�^�[���폜
            Destroy(gameObject);
        }

        // �Փ˂����I�u�W�F�N�g���uBaria�v�^�O���ǂ������m�F
        if (collision.gameObject.CompareTag("Baria"))
        {
            // �����X�^�[���폜
            Destroy(gameObject);
        }
    }

    // �T�E���h�Đ���Ƀ����X�^�[���폜����R���[�`��
    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }
}
