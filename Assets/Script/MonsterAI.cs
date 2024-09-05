using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform��ݒ�
    public float moveSpeed = 2f; // �����X�^�[�̈ړ����x

    private void Update()
    {
        // �v���C���[�܂ł̋������v�Z
        float distance = Vector2.Distance(transform.position, player.position);

        // �v���C���[���w�肵�������ȓ��ɂ���ꍇ
        if (distance < 10f) // �����ŋ����͈̔͂�ݒ�
        {
            // �v���C���[�̕��Ɍ������Ĉړ�
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
