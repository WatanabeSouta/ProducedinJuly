using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Baria : MonoBehaviour
{
    public Slider slider; // Slider コンポーネントをアタッチ
    public GameObject barrierObject; // バリアオブジェクト

    private bool isBarrierActive;

    private void Start()
    {
        // バリアがアクティブかどうかをチェックしてスライダーを初期化
        //isBarrierActive = barrierObject.activeSelf;
       // UpdateSlider(isBarrierActive);
    }

    private void Update()
    {
        // バリアオブジェクトの表示状態が変わったかチェック
        bool currentBarrierState = barrierObject.activeSelf;
        if (currentBarrierState != isBarrierActive)
        {
            // 状態が変わった場合にスライダーを更新
            isBarrierActive = currentBarrierState;
            UpdateSlider(isBarrierActive);
        }
    }

    private void UpdateSlider(bool isActive)
    {
        if (isActive)
        {
            // バリアがアクティブなときはスライダーを1秒で減らす
            StartCoroutine(ChangeSliderValue(slider.value, 0f, 1f));
        }
        else
        {
            // バリアが非アクティブなときはスライダーを5秒で戻す
            StartCoroutine(ChangeSliderValue(slider.value, 1f, 5f));
        }
    }

    private IEnumerator ChangeSliderValue(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            yield return null;
        }
        slider.value = endValue; // 最終値を設定
    }
}
