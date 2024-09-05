using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public float bulletSpeed = 10f;  // 弾の速度
    public float fireRate = 0.5f;    // 弾を発射する間隔（秒）

    private float nextFireTime = 0f; // 次に弾を発射できる時間

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // 左クリックかつ発射可能な時間
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // 次の発射可能時間を設定
        }
    }

    void Shoot()
    {
        // プレハブが設定されているか確認
        if (bulletPrefab != null)
        {
            // 弾をインスタンス化
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // マウスカーソルの位置を取得
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2DゲームなのでZ軸の値を0にする

            // 弾の発射方向を計算
            Vector2 direction = (mousePosition - transform.position).normalized;

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
}
