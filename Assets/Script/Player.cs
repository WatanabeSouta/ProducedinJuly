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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D コンポーネントを取得
    }

    void Update()
    {
        // 横移動の処理
        float moveInput = Input.GetAxis("Horizontal");

        // スプライトの向きを変更
        if (moveInput < 0)
        {
            // 左に移動する場合
            if (transform.localScale.x > 0)
            {
                // 右向きから左向きに変更
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (moveInput > 0)
        {
            // 右に移動する場合
            if (transform.localScale.x < 0)
            {
                // 左向きから右向きに変更
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        // プレイヤーの移動
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ジャンプの処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true; // 地面にいるときはダブルジャンプをリセット
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false; // ダブルジャンプを一度だけ可能に
            }
        }

        // 弾の発射処理
        if (Input.GetMouseButtonDown(0)) // 左クリック
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
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 地面に接触したとき
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // 地面から離れたとき
        }
    }
}
