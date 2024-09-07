using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float jumpForce = 10f; // �W�����v��
    private bool isGrounded = false; // �v���C���[���n�ʂɂ��邩�ǂ���
    private bool canDoubleJump = true; // �_�u���W�����v���\���ǂ���
    private Rigidbody2D rb; // Rigidbody2D �R���|�[�l���g
    public GameObject bulletPrefab; // �e�̃v���n�u
    public Transform firePoint; // �e�̔��ˈʒu
    public float bulletSpeed = 10f; // �e�̑��x

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D �R���|�[�l���g���擾
    }

    void Update()
    {
        // ���ړ��̏���
        float moveInput = Input.GetAxis("Horizontal");

        // �X�v���C�g�̌�����ύX
        if (moveInput < 0)
        {
            // ���Ɉړ�����ꍇ
            if (transform.localScale.x > 0)
            {
                // �E�������獶�����ɕύX
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (moveInput > 0)
        {
            // �E�Ɉړ�����ꍇ
            if (transform.localScale.x < 0)
            {
                // ����������E�����ɕύX
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        // �v���C���[�̈ړ�
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // �W�����v�̏���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true; // �n�ʂɂ���Ƃ��̓_�u���W�����v�����Z�b�g
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false; // �_�u���W�����v����x�����\��
            }
        }

        // �e�̔��ˏ���
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            Shoot();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // �W�����v�̗͂�������
    }

    void Shoot()
    {
        if (bulletPrefab && firePoint)
        {
            // �}�E�X�J�[�\���̈ʒu���擾
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 2D�Ȃ̂�z���͖���

            // �v���C���[�̌����ɉ��������˕������v�Z
            Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

            // �v���C���[�����������Ă���ꍇ�A���˕����Ƀ}�C�i�X��������
            if (transform.localScale.x < 0)
            {
                shootDirection = new Vector2(-shootDirection.x, shootDirection.y); // ���˕����𔽓]
            }

            // ���˕����̊p�x���v�Z
            float angle = Vector2.SignedAngle(Vector2.right, shootDirection);

            // ���˔͈͂�ݒ�
            if (transform.localScale.x > 0) // �E����
            {
                if (angle < -60 || angle > 60) return; // �͈͊O
            }
            else // ������
            {
                if (angle > 60 || angle < -60) return; // �͈͊O
            }

            // �e�𔭎�
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if (bulletRb)
            {
                // �v���C���[�����������Ă���Ƃ��A�e�̐i�ތ��������]
                if (transform.localScale.x < 0)
                {
                    bulletRb.velocity = new Vector2(-shootDirection.x, shootDirection.y) * bulletSpeed;
                }
                else
                {
                    bulletRb.velocity = shootDirection * bulletSpeed;
                }
            }
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // �n�ʂɐڐG�����Ƃ�
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // �n�ʂ��痣�ꂽ�Ƃ�
        }
    }
}
