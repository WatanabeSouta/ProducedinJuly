using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health = 100; // �����X�^�[�̏���HP

    // �����X�^�[���_���[�W���󂯂郁�\�b�h
    public void TakeDamage(int damage)
    {
        health -= damage; // HP�����炷
        if (health <= 0)
        {
            Die(); // HP��0�ȉ��ɂȂ����玀��
        }
    }

    // �����X�^�[�����ʏ���
    private void Die()
    {
        // �����X�^�[���폜����Ȃǂ̏���
        Destroy(gameObject); // �����X�^�[���폜
    }
}
