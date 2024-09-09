using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // アニメーターコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // シフトキーが押されているか確認
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // アニメーターのパラメーターを設定
        animator.SetBool("isRunning", isRunning);
    }
}
