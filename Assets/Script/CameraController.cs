using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // プレイヤーなど追従する対象
    public float yOffset = -2f; // プレイヤーの位置からカメラの位置までのオフセット
    public Vector2 minBounds; // 左下の壁の座標
    public Vector2 maxBounds; // 右上の壁の座標

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            // シーン開始時にカメラをプレイヤーの位置に移動
            Vector3 startCameraPos = target.transform.position;
            startCameraPos.z = -10; // カメラのz位置を固定
            transform.position = startCameraPos + new Vector3(0, yOffset, 0);
        }
        else
        {
            Debug.LogError("Targetが設定されていません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // プレイヤーの位置を取得
            Vector3 cameraPos = target.transform.position;

            // カメラの位置をプレイヤーの位置より下に設定
            cameraPos.z = -10; // カメラの奥行きを固定
            cameraPos.y += yOffset; // プレイヤーの位置からのオフセットを適用

            // カメラの位置を範囲内に制限
            cameraPos.x = Mathf.Clamp(cameraPos.x, minBounds.x, maxBounds.x);
            cameraPos.y = Mathf.Clamp(cameraPos.y, minBounds.y, maxBounds.y);

            transform.position = cameraPos;
        }
    }
}
