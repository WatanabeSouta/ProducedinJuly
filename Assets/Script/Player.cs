using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 10f; // ジャンプ力
    private bool isGrounded = false; // プレイヤーが地面にいるかどうか
    private bool canDoubleJump = true; // ダブルジャンプが可能かどうか
    private Rigidbody2D rb; // Rigidbody2D コンポーネント

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D コンポーネントを取得
    }

    void Update()
    {
        // 横移動の処理
        float moveInput = Input.GetAxis("Horizontal");

        // スプライトの向きを変更
        if (moveInput > 0)
        {
            // 右に移動する場合
            if (transform.localScale.x < 0)
            {
                // 左向きから右向きに変更
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (moveInput < 0)
        {
            // 左に移動する場合
            if (transform.localScale.x > 0)
            {
                // 右向きから左向きに変更
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
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ジャンプの力を加える
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
