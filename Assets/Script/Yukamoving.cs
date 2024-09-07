using UnityEngine;

public class Yukamoving : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(1, 0, 0); // ����
    public float speed = 2f; // �ړ����x

    private bool isPlayerOnPlatform = false; // �v���C���[������Ă���
    private Vector3 initialPosition; // �����ʒu

    void Start()
    {
        // �����ʒu
        initialPosition = transform.position;
    }

    void Update()
    {
        //�����ړ�������
        if (isPlayerOnPlatform)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }

        //�����ʒu�Œ�
        transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
    }

    //���ɏ�����Ƃ��ɌĂ΂��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    //���ꂽ�Ƃ��ɌĂ΂��
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }
}
