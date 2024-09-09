using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening; // DOTween を使うための名前空間
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10f; // プレイヤーの最大HP
    private float currentHealth;   // 現在のHP
    public string gameOverScene;   // ゲームオーバー時に移動するシーン名
    public Color hitColor = Color.red; // 衝突時の色（赤）
    public float hitColorDuration = 0.1f; // 衝突時の色変更の時間（0.1秒）

    public Slider healthSlider;    // HPバーのUIスライダー
    private SpriteRenderer spriteRenderer; // プレイヤーのスプライトの色を変更するためのコンポーネント

    void Start()
    {
        // ゲーム開始時にHPを最大に設定
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>(); // スプライトのコンポーネントを取得

        // スプライトが見つからない場合はエラーメッセージを表示
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the player object.");
        }

        // HPバーの初期設定
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth; // スライダーの最大値を設定
            healthSlider.value = currentHealth; // スライダーの現在値を設定
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーがモンスターに衝突したとき
        if (collision.gameObject.CompareTag("Monster"))
        {
            StartCoroutine(FlashRed()); // プレイヤーを赤くフラッシュさせる
        }
    }

    // プレイヤーがダメージを受けたときの処理
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ダメージをHPから引く
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // HPが範囲外にならないように制限

        // HPバーのアニメーションを設定
        if (healthSlider != null)
        {
            healthSlider.DOKill(); // 既存のアニメーションをキャンセル
            healthSlider.DOValue(currentHealth, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                // HPバーのアニメーションが終了した後に死亡判定
                if (currentHealth <= 0)
                {
                    StartCoroutine(HandleGameOver()); // ゲームオーバー処理をコルーチンで実行
                }
            });
        }
        else
        {
            // HPバーがない場合は即座に死亡判定
            if (currentHealth <= 0)
            {
                StartCoroutine(HandleGameOver());
            }
        }
    }
    // ゲームオーバー時の処理
    private IEnumerator HandleGameOver()
    {
        // ゲームの時間を停止
        Time.timeScale = 0f;

        // 1秒待機
        yield return new WaitForSecondsRealtime(0.1f);

        // シーン遷移の処理を実行
        ChangeScene();

        // ゲームの時間を元に戻す（シーン遷移後にゲームが再開されるように）
        Time.timeScale = 1f;
    }


    // シーンを変更する処理
    void ChangeScene()
    {
        SceneManager.LoadScene(gameOverScene); // 指定されたシーンに移動する
    }

    // プレイヤーを赤くフラッシュさせる処理
    private IEnumerator FlashRed()
    {
        if (spriteRenderer != null)
        {
            Color originalColor = spriteRenderer.color; // 元の色を保存
            spriteRenderer.color = hitColor; // プレイヤーを赤くする
            yield return new WaitForSeconds(hitColorDuration); // 指定された時間待機
            spriteRenderer.color = originalColor; // 色を元に戻す
        }
    }
}
