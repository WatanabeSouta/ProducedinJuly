using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; // DOTween ���g�����߂̖��O���

public class Health : MonoBehaviour
{
    [SerializeField] private Image _hpBarcurrent; // HP�o�[��UI Image�R���|�[�l���g
    [SerializeField] private float _maxHealth;    // �ő�HP
    private float currentHealth;                  // ���݂�HP
    [SerializeField] private float animationDuration = 0.5f; // HP�o�[�̃A�j���[�V��������

    void Awake()
    {
        // �ő�HP��0�łȂ����m�F���A�����l��ݒ�
        if (_maxHealth <= 0)
        {
            Debug.LogError("MaxHealth must be greater than 0.");
            _maxHealth = 1; // �f�t�H���g�l��ݒ�
        }

        currentHealth = _maxHealth; // ���݂�HP���ő�HP�ŏ�����
        if (_hpBarcurrent != null)
        {
            UpdateHP(0); // ����������HP�o�[���X�V
        }
        else
        {
            Debug.LogError("HPBar Image component is not assigned.");
        }
    }

    public void UpdateHP(float damage)
    {
        // ���݂�HP���X�V
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, _maxHealth);
        // HP�o�[�̒l���A�j���[�V�����ŕύX
        if (_hpBarcurrent != null)
        {
            _hpBarcurrent.DOFillAmount(currentHealth / _maxHealth, animationDuration).SetEase(Ease.Linear);
        }
        else
        {
            Debug.LogError("HPBar Image component is not assigned.");
        }
    }

    // ���݂�HP���擾����v���p�e�B
    public float CurrentHealth
    {
        get { return currentHealth; }
    }
}
