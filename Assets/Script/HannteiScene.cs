using UnityEngine;
using UnityEngine.SceneManagement;

public class HannteiScene : MonoBehaviour
{
    // �V�[������ݒ肵�܂�
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���w�肵���^�O�������Ă��邩�m�F���܂�
        if (collision.gameObject.CompareTag("Player"))
        {
            // �V�[����ύX���܂�
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
