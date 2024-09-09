using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    // �Փˎ��ɃV�[����J�ڂ�����^�[�Q�b�g�̃^�O
    public string targetTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        // �Փ˂����I�u�W�F�N�g���w�肵���^�O�̂��̂��ǂ������`�F�b�N
        if (other.CompareTag(targetTag))
        {
            // �J�ڂ���V�[���̖��O�i�V�[���̃r���h�ݒ�Őݒ肳�ꂽ���O�j
            string sceneName = "ClearScene"; // �J�ڐ�̃V�[�����ɕύX

            // �V�[����J��
            SceneManager.LoadScene(sceneName);
        }
    }
}
