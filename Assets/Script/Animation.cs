using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �V�t�g�L�[��������Ă��邩�m�F
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // �A�j���[�^�[�̃p�����[�^�[��ݒ�
        animator.SetBool("isRunning", isRunning);
    }
}
