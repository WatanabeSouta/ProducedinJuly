using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSenni : MonoBehaviour
{
    public Button myButton; // �C���X�y�N�^�Őݒ�
    public string sceneName = "HajimarinoScene"; // �J�ڂ���V�[���̖��O
    public AudioClip soundClip; // �Đ�����T�E���h�̃N���b�v
    public float delayBeforeTransition = 1.0f; // �T�E���h���I��������ɑJ�ڂ���܂ł̎���

    private AudioSource audioSource;

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

        // AudioSource�̃Z�b�g�A�b�v
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = soundClip;
    }

    void OnButtonClick()
    {
        // �T�E���h���Đ����A�J�ڏ������J�n����
        StartCoroutine(PlaySoundAndTransition());
    }

    IEnumerator PlaySoundAndTransition()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.Play();
            // �T�E���h�̒����ƒx�����Ԃ����������Ԃ����ҋ@
            yield return new WaitForSeconds(audioSource.clip.length + delayBeforeTransition);
        }
        // �V�[����J�ڂ���
        SceneManager.LoadScene(sceneName);
    }
}
