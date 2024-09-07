using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public float bulletSpeed = 10f;  // 弾の速度
    public float fireRate = 0.5f;    // 弾を発射する間隔（秒）
    public float shootAngleRange = 60f; // 発射方向の角度範囲（±60度）

    private float nextFireTime = 0f; // 次に弾を発射できる時間

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // 左クリックかつ発射可能な時間
        {
            // マウスカーソルの位置を取得
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2DゲームなのでZ軸の値を0にする

            // プレイヤーが向いている方向を取得
            float playerFacingDirection = transform.localScale.x > 0 ? 0 : 180;
            float angleToMouse = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

            // プレイヤーの向きに応じて角度範囲を決定
            float minAngle, maxAngle;
            if (playerFacingDirection == 0)
            {
                // プレイヤーが右を向いているとき
                minAngle = -shootAngleRange;
                maxAngle = shootAngleRange;
            }
            else
            {
                // プレイヤーが左を向いているとき
                minAngle = 180 - shootAngleRange;
                maxAngle = 180 + shootAngleRange;
            }

            // マウスカーソルの角度が範囲内かチェック
            if (IsAngleInRange(angleToMouse, minAngle, maxAngle))
            {
                Vector2 direction = (mousePosition - transform.position).normalized;

                // プレイヤーが左を向いているとき、弾の向きを反転
                if (playerFacingDirection == 180)
                {
                    direction = -direction;
                }

                Shoot(direction);
                nextFireTime = Time.time + fireRate; // 次の発射可能時間を設定
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        // プレハブが設定されているか確認
        if (bulletPrefab != null)
        {
            // 弾をインスタンス化
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // 弾に速度を適用
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
            else
            {
                Debug.LogError("Bullet prefab does not have a Rigidbody2D component.");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }

    bool IsAngleInRange(float angle, float minAngle, float maxAngle)
    {
        if (minAngle < -180) minAngle += 360;
        if (maxAngle > 180) maxAngle -= 360;

        if (minAngle < maxAngle)
        {
            return angle >= minAngle && angle <= maxAngle;
        }
        else
        {
            return angle >= minAngle || angle <= maxAngle;
        }
    }
}
