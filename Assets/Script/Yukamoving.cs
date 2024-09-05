using UnityEngine;

public class Yukamoving : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(1, 0, 0); // �ړ�����
    public float speed = 2f; // �ړ����x

    private bool isPlayerOnPlatform = false; // �v���C���[������Ă��邩�̃t���O

    void Update()
    {
        // �v���C���[������Ă���ԁA�����ړ�������
        if (isPlayerOnPlatform)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    // �v���C���[�����ɏ�����Ƃ��ɌĂ΂��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            // �v���C���[�����̎q�I�u�W�F�N�g�ɂ��Ȃ�
        }
    }

    // �v���C���[�������痣�ꂽ�Ƃ��ɌĂ΂��
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            // �v���C���[�����̎q�I�u�W�F�N�g����������Ȃ�
        }
    }
}
