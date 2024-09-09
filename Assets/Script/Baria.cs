using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Baria : MonoBehaviour
{
    public Slider slider; // Slider �R���|�[�l���g���A�^�b�`
    public GameObject barrierObject; // �o���A�I�u�W�F�N�g

    private bool isBarrierActive;

    private void Start()
    {
        // �o���A���A�N�e�B�u���ǂ������`�F�b�N���ăX���C�_�[��������
        //isBarrierActive = barrierObject.activeSelf;
       // UpdateSlider(isBarrierActive);
    }

    private void Update()
    {
        // �o���A�I�u�W�F�N�g�̕\����Ԃ��ς�������`�F�b�N
        bool currentBarrierState = barrierObject.activeSelf;
        if (currentBarrierState != isBarrierActive)
        {
            // ��Ԃ��ς�����ꍇ�ɃX���C�_�[���X�V
            isBarrierActive = currentBarrierState;
            UpdateSlider(isBarrierActive);
        }
    }

    private void UpdateSlider(bool isActive)
    {
        if (isActive)
        {
            // �o���A���A�N�e�B�u�ȂƂ��̓X���C�_�[��1�b�Ō��炷
            StartCoroutine(ChangeSliderValue(slider.value, 0f, 1f));
        }
        else
        {
            // �o���A����A�N�e�B�u�ȂƂ��̓X���C�_�[��5�b�Ŗ߂�
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
        slider.value = endValue; // �ŏI�l��ݒ�
    }
}
