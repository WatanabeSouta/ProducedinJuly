using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; // DOTween を使うための名前空間

public class Health : MonoBehaviour
{
    [SerializeField] private Image _hpBarcurrent; // HPバーのUI Imageコンポーネント
    [SerializeField] private float _maxHealth;    // 最大HP
    private float currentHealth;                  // 現在のHP
    [SerializeField] private float animationDuration = 0.5f; // HPバーのアニメーション時間

    void Awake()
    {
        // 最大HPが0でないか確認し、初期値を設定
        if (_maxHealth <= 0)
        {
            Debug.LogError("MaxHealth must be greater than 0.");
            _maxHealth = 1; // デフォルト値を設定
        }

        currentHealth = _maxHealth; // 現在のHPを最大HPで初期化
        if (_hpBarcurrent != null)
        {
            UpdateHP(0); // 初期化時にHPバーを更新
        }
        else
        {
            Debug.LogError("HPBar Image component is not assigned.");
        }
    }

    public void UpdateHP(float damage)
    {
        // 現在のHPを更新
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, _maxHealth);
        // HPバーの値をアニメーションで変更
        if (_hpBarcurrent != null)
        {
            _hpBarcurrent.DOFillAmount(currentHealth / _maxHealth, animationDuration).SetEase(Ease.Linear);
        }
        else
        {
            Debug.LogError("HPBar Image component is not assigned.");
        }
    }

    // 現在のHPを取得するプロパティ
    public float CurrentHealth
    {
        get { return currentHealth; }
    }
}
