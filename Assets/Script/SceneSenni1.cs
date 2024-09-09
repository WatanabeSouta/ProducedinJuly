using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSenni1 : MonoBehaviour
{
    public Button myButton; // インスペクタで設定
    public string sceneName = "HajimarinoScene"; // 遷移するシーンの名前

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
    }

    void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
