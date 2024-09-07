using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // カメラが追いかける対象（プレイヤーなど）
    public float yOffset = -2f; // カメラの上下位置の調整
    public float minX; // カメラが動ける左端の位置
    public float maxX; // カメラが動ける右端の位置

    // ゲームが始まるときに呼ばれる
    void Start()
    {
        if (target != null)
        {
            // カメラの初期位置を設定
            Vector3 startPos = target.transform.position;
            startPos.z = -10; // カメラの奥行きを固定
            startPos.x = Mathf.Clamp(startPos.x, minX, maxX); // カメラの左右の位置を制限
            transform.position = startPos + new Vector3(0, yOffset, 0);
        }
        else
        {
            Debug.LogError("Targetが設定されていません");
        }
    }

    // 毎フレームごとに呼ばれる
    void Update()
    {
        if (target != null)
        {
            // カメラの位置をプレイヤーの位置に合わせて更新
            Vector3 cameraPos = target.transform.position;
            cameraPos.z = -10; // カメラの奥行きを固定
            cameraPos.x = Mathf.Clamp(cameraPos.x, minX, maxX); // 左右の制限を適用
            cameraPos.y += yOffset; // 上下の位置調整
            transform.position = cameraPos;
        }
    }
}
