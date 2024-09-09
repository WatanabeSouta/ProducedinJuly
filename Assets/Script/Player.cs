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
    public float fireRate = 0.2f; // �e�𔭎˂���Ԋu�i�b�j
    private float nextFire = 0f; // ���ɒe�𔭎˂ł��鎞��

    private bool isInEffectArea = false; // �G���A�G�t�F�N�g���ɂ��邩�ǂ���

    private bool canMove = true; // �v���C���[�������邩�ǂ���
    private bool isShiftPressed = false; // �V�t�g�L�[��������Ă��邩�ǂ���
    private float shiftReleaseTime = 0f; // �V�t�g�L�[�𗣂��Ă���̎��Ԍv���p
    public float shiftDelay = 2f; // �V�t�g�L�[�𗣂��Ă���o���A���\���ɂ��鎞�ԁi�b�j

    public float barrierCooldown = 5f; // �o���A�̃N�[���_�E�����ԁi�b�j
    private float barrierReadyTime = 0f; // �o���A���ēx�\���ł���悤�ɂȂ鎞�ԁi�b�j

    public GameObject targetObject; // �\��/��\��������Ώۂ̃I�u�W�F�N�g

    public AudioClip shiftSound; // �V�t�g�L�[�̌��ʉ�
    public AudioClip shootSound; // �e���˂̌��ʉ�
    private AudioSource audioSource; // AudioSource �R���|�[�l���g

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D �R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>(); // AudioSource �R���|�[�l���g���擾

        if (targetObject != null)
        {
            targetObject.SetActive(false); // ������ԂŃI�u�W�F�N�g���\���ɂ���
        }
    }

    void Update()
    {
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (shiftPressed)
        {
            if (!isShiftPressed)
            {
                isShiftPressed = true;

                if (targetObject != null && Time.time >= barrierReadyTime)
                {
                    targetObject.SetActive(true);
                }

                // �V�t�g�L�[�̌��ʉ����Đ�
                if (audioSource && shiftSound)
                {
                    audioSource.PlayOneShot(shiftSound);
                }
            }
            canMove = true;
        }
        else
        {
            if (isShiftPressed)
            {
                isShiftPressed = false;
                shiftReleaseTime = Time.time + shiftDelay;
                barrierReadyTime = Time.time + barrierCooldown;
            }
        }

        // �o���A�̔�\������
        if (!shiftPressed && Time.time >= shiftReleaseTime)
        {
            if (targetObject != null && targetObject.activeSelf)
            {
                targetObject.SetActive(false);
            }
        }

        // ���ړ��̏���
        float moveInput = Input.GetAxis("Horizontal");

        // �X�v���C�g�̌�����ύX
        if (moveInput < 0)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (moveInput > 0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        // �v���C���[�̈ړ�
        if (canMove)
        {
            float effectiveMoveSpeed = isInEffectArea ? moveSpeed * 0.5f : moveSpeed;
            rb.velocity = new Vector2(moveInput * effectiveMoveSpeed, rb.velocity.y);
        }

        // �W�����v�̏���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        // �e�̔��ˏ���
        if (Input.GetMouseButtonDown(0))
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
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate; // ���ɒe�𔭎˂ł��鎞����ݒ�

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

                // �e���˂̌��ʉ����Đ�
                if (audioSource && shootSound)
                {
                    audioSource.PlayOneShot(shootSound);
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
        else if (collision.gameObject.CompareTag("EffectArea"))
        {
            isInEffectArea = true; // �G���A�G�t�F�N�g���ɓ������Ƃ�
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // �n�ʂ��痣�ꂽ�Ƃ�
        }
        else if (collision.gameObject.CompareTag("EffectArea"))
        {
            isInEffectArea = false; // �G���A�G�t�F�N�g����o���Ƃ�
        }
    }
}
