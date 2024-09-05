using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public float bulletSpeed = 10f;  // �e�̑��x
    public float fireRate = 0.5f;    // �e�𔭎˂���Ԋu�i�b�j

    private float nextFireTime = 0f; // ���ɒe�𔭎˂ł��鎞��

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // ���N���b�N�����ˉ\�Ȏ���
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // ���̔��ˉ\���Ԃ�ݒ�
        }
    }

    void Shoot()
    {
        // �v���n�u���ݒ肳��Ă��邩�m�F
        if (bulletPrefab != null)
        {
            // �e���C���X�^���X��
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // �}�E�X�J�[�\���̈ʒu���擾
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D�Q�[���Ȃ̂�Z���̒l��0�ɂ���

            // �e�̔��˕������v�Z
            Vector2 direction = (mousePosition - transform.position).normalized;

            // �e�ɑ��x��K�p
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
