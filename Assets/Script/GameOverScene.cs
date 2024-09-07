using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI���g�����߂̖��O���

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; // �Q�[���I�[�o�[�̃e�L�X�g�I�u�W�F�N�g
    public AudioClip gameOverSound; // �Q�[���I�[�o�[�̃T�E���h
    public string sceneToLoad; // �ύX�������V�[���̖��O
    private AudioSource audioSource; // �T�E���h���Đ����邽�߂̃R���|�[�l���g

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();

        // �Q�[���I�[�o�[�̃e�L�X�g��������ԂŔ�\���ɂ���
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���uPlayer�v���m�F����
        if (collision.CompareTag("Player"))
        {
            // �v���C���[�I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

            // �Q�[���I�[�o�[�̃T�E���h���Đ�����
            if (gameOverSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(gameOverSound);
            }

            // 3�b��ɃQ�[���I�[�o�[�̃e�L�X�g��\������
            Invoke("ShowGameOverText", 2f);

            // 6�b��ɃV�[����ύX����
            Invoke("ChangeScene", 5f); // �e�L�X�g���\������Ă���3�b��ɃV�[���ύX
        }
    }

    void ShowGameOverText()
    {
        // �Q�[���I�[�o�[�̃e�L�X�g��\������
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }
    }

    void ChangeScene()
    {
        // �w�肵���V�[����ǂݍ���
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
