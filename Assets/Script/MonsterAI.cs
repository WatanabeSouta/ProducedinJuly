using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject player; // �����Ƀv���C���[�I�u�W�F�N�g�����蓖�Ă�
    public float speed = 2.0f; // �����X�^�[�̈ړ����x

    private void Start()
    {
        // player�����蓖�Ă��Ă��Ȃ���΁A�����ŒT���Đݒ�
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // �v���C���[�̈ʒu���擾
            Vector3 playerPosition = player.transform.position;

            // �����X�^�[�̈ʒu���擾
            Vector3 monsterPosition = transform.position;

            // �v���C���[�Ɍ������Ĉړ����邽�߂̃x�N�g�����v�Z
            Vector3 direction = (playerPosition - monsterPosition).normalized;

            // Rigidbody2D�R���|�[�l���g���擾
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // �v���C���[�̕����Ɉړ�
                rb.velocity = direction * speed;
            }
        }
        else
        {
            // player��null�̏ꍇ�A���x���[���ɂ���
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
