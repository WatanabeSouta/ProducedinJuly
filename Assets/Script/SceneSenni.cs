using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSenni : MonoBehaviour
{
    public Button myButton; // インスペクタで設定
    public string sceneName = "HajimarinoScene"; // 遷移するシーンの名前
    public AudioClip soundClip; // 再生するサウンドのクリップ
    public float delayBeforeTransition = 1.0f; // サウンドが終了した後に遷移するまでの時間

    private AudioSource audioSource;

    void Start()
    {
        // ボタンがセットされていない場合は自動でボタンを探します
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

        // AudioSourceのセットアップ
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = soundClip;
    }

    void OnButtonClick()
    {
        // サウンドを再生し、遷移処理を開始する
        StartCoroutine(PlaySoundAndTransition());
    }

    IEnumerator PlaySoundAndTransition()
    {
        if (audioSource != null && soundClip != null)
        {
            audioSource.Play();
            // サウンドの長さと遅延時間を加えた時間だけ待機
            yield return new WaitForSeconds(audioSource.clip.length + delayBeforeTransition);
        }
        // シーンを遷移する
        SceneManager.LoadScene(sceneName);
    }
}
