using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 10f; // ジャンプ力
    private bool isGrounded = false; // プレイヤーが地面にいるかどうか
    private bool canDoubleJump = true; // ダブルジャンプが可能かどうか
    private Rigidbody2D rb; // Rigidbody2D コンポーネント
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint; // 弾の発射位置
    public float bulletSpeed = 10f; // 弾の速度
    public float fireRate = 0.2f; // 弾を発射する間隔（秒）
    private float nextFire = 0f; // 次に弾を発射できる時刻

    private bool isInEffectArea = false; // エリアエフェクト内にいるかどうか

    private bool canMove = true; // プレイヤーが動けるかどうか
    private bool isShiftPressed = false; // シフトキーが押されているかどうか
    private float shiftReleaseTime = 0f; // シフトキーを離してからの時間計測用
    public float shiftDelay = 2f; // シフトキーを離してからバリアを非表示にする時間（秒）

    public float barrierCooldown = 5f; // バリアのクールダウン時間（秒）
    private float barrierReadyTime = 0f; // バリアを再度表示できるようになる時間（秒）

    public GameObject targetObject; // 表示/非表示させる対象のオブジェクト

    public AudioClip shiftSound; // シフトキーの効果音
    public AudioClip shootSound; // 弾発射の効果音
    private AudioSource audioSource; // AudioSource コンポーネント

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D コンポーネントを取得
        audioSource = GetComponent<AudioSource>(); // AudioSource コンポーネントを取得

        if (targetObject != null)
        {
            targetObject.SetActive(false); // 初期状態でオブジェクトを非表示にする
        }
    }

    void Update()
    {
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (shiftPressed)
        {
            if (!isShiftPressed)
            {
                isShiftPressed = true;

                if (targetObject != null && Time.time >= barrierReadyTime)
                {
                    targetObject.SetActive(true);
                }

                // シフトキーの効果音を再生
                if (audioSource && shiftSound)
                {
                    audioSource.PlayOneShot(shiftSound);
                }
            }
            canMove = true;
        }
        else
        {
            if (isShiftPressed)
            {
                isShiftPressed = false;
                shiftReleaseTime = Time.time + shiftDelay;
                barrierReadyTime = Time.time + barrierCooldown;
            }
        }

        // バリアの非表示処理
        if (!shiftPressed && Time.time >= shiftReleaseTime)
        {
            if (targetObject != null && targetObject.activeSelf)
            {
                targetObject.SetActive(false);
            }
        }

        // 横移動の処理
        float moveInput = Input.GetAxis("Horizontal");

        // スプライトの向きを変更
        if (moveInput < 0)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (moveInput > 0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        // プレイヤーの移動
        if (canMove)
        {
            float effectiveMoveSpeed = isInEffectArea ? moveSpeed * 0.5f : moveSpeed;
            rb.velocity = new Vector2(moveInput * effectiveMoveSpeed, rb.velocity.y);
        }

        // ジャンプの処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        // 弾の発射処理
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ジャンプの力を加える
    }

    void Shoot()
    {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate; // 次に弾を発射できる時刻を設定

            if (bulletPrefab && firePoint)
            {
                // マウスカーソルの位置を取得
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // 2Dなのでz軸は無視

                // プレイヤーの向きに応じた発射方向を計算
                Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

                // プレイヤーが左を向いている場合、発射方向にマイナスをかける
                if (transform.localScale.x < 0)
                {
                    shootDirection = new Vector2(-shootDirection.x, shootDirection.y); // 発射方向を反転
                }

                // 発射方向の角度を計算
                float angle = Vector2.SignedAngle(Vector2.right, shootDirection);

                // 発射範囲を設定
                if (transform.localScale.x > 0) // 右向き
                {
                    if (angle < -60 || angle > 60) return; // 範囲外
                }
                else // 左向き
                {
                    if (angle > 60 || angle < -60) return; // 範囲外
                }

                // 弾を発射
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb)
                {
                    // プレイヤーが左を向いているとき、弾の進む向きも反転
                    if (transform.localScale.x < 0)
                    {
                        bulletRb.velocity = new Vector2(-shootDirection.x, shootDirection.y) * bulletSpeed;
                    }
                    else
                    {
                        bulletRb.velocity = shootDirection * bulletSpeed;
                    }
                }

                // 弾発射の効果音を再生
                if (audioSource && shootSound)
                {
                    audioSource.PlayOneShot(shootSound);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 地面に接触したとき
        }
        else if (collision.gameObject.CompareTag("EffectArea"))
        {
            isInEffectArea = true; // エリアエフェクト内に入ったとき
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // 地面から離れたとき
        }
        else if (collision.gameObject.CompareTag("EffectArea"))
        {
            isInEffectArea = false; // エリアエフェクトから出たとき
        }
    }
}
