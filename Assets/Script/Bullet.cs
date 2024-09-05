using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // �e�̃_���[�W��

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Monster"))
        {
            // �Փ˂����I�u�W�F�N�g���uMonster�v�̏ꍇ�A�_���[�W��^���Ă���e���폜
            if (other.CompareTag("Monster"))
            {
                Monster monster = other.GetComponent<Monster>();
                if (monster != null)
                {
                    monster.TakeDamage(damage); // �����X�^�[�Ƀ_���[�W��^����
                }
            }

            // �Փ˂����I�u�W�F�N�g���uGround�v�܂��́uMonster�v�̏ꍇ�A�e���폜
            Destroy(gameObject); // �e���폜
        }
    }
}
