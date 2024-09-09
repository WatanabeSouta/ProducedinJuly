using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 10;  // �^����_���[�W��

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[��Health�X�N���v�g���擾
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);  // �_���[�W��^����
            }
        }
    }
}
