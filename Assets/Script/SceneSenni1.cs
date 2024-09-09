using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSenni1 : MonoBehaviour
{
    public Button myButton; // �C���X�y�N�^�Őݒ�
    public string sceneName = "HajimarinoScene"; // �J�ڂ���V�[���̖��O

    void Start()
    {
        // �{�^�����Z�b�g����Ă��Ȃ��ꍇ�͎����Ń{�^����T���܂�
        if (myButton == null)
        {
            myButton = GetComponent<Button>();
        }

        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button is not assigned!");
        }
    }

    void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
