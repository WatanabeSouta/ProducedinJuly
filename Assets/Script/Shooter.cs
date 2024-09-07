using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public float bulletSpeed = 10f;  // �e�̑��x
    public float fireRate = 0.5f;    // �e�𔭎˂���Ԋu�i�b�j
    public float shootAngleRange = 60f; // ���˕����̊p�x�͈́i�}60�x�j

    private float nextFireTime = 0f; // ���ɒe�𔭎˂ł��鎞��

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime) // ���N���b�N�����ˉ\�Ȏ���
        {
            // �}�E�X�J�[�\���̈ʒu���擾
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D�Q�[���Ȃ̂�Z���̒l��0�ɂ���

            // �v���C���[�������Ă���������擾
            float playerFacingDirection = transform.localScale.x > 0 ? 0 : 180;
            float angleToMouse = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

            // �v���C���[�̌����ɉ����Ċp�x�͈͂�����
            float minAngle, maxAngle;
            if (playerFacingDirection == 0)
            {
                // �v���C���[���E�������Ă���Ƃ�
                minAngle = -shootAngleRange;
                maxAngle = shootAngleRange;
            }
            else
            {
                // �v���C���[�����������Ă���Ƃ�
                minAngle = 180 - shootAngleRange;
                maxAngle = 180 + shootAngleRange;
            }

            // �}�E�X�J�[�\���̊p�x���͈͓����`�F�b�N
            if (IsAngleInRange(angleToMouse, minAngle, maxAngle))
            {
                Vector2 direction = (mousePosition - transform.position).normalized;

                // �v���C���[�����������Ă���Ƃ��A�e�̌����𔽓]
                if (playerFacingDirection == 180)
                {
                    direction = -direction;
                }

                Shoot(direction);
                nextFireTime = Time.time + fireRate; // ���̔��ˉ\���Ԃ�ݒ�
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        // �v���n�u���ݒ肳��Ă��邩�m�F
        if (bulletPrefab != null)
        {
            // �e���C���X�^���X��
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

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

    bool IsAngleInRange(float angle, float minAngle, float maxAngle)
    {
        if (minAngle < -180) minAngle += 360;
        if (maxAngle > 180) maxAngle -= 360;

        if (minAngle < maxAngle)
        {
            return angle >= minAngle && angle <= maxAngle;
        }
        else
        {
            return angle >= minAngle || angle <= maxAngle;
        }
    }
}
