using UnityEngine;

public class Delete : MonoBehaviour
{
    // �Փˎ��ɌĂ΂�郁�\�b�h
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���uDelete�v�̏ꍇ
        if (collision.CompareTag("Delete"))
        {
            // ���̃I�u�W�F�N�g���폜����
            Destroy(gameObject);
        }
    }
}
