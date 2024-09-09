using UnityEngine;
using System.Collections;

public class Hosi : MonoBehaviour
{
    public float speed = 5f; // �����X�^�[�̈ړ����x

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // �����Ɉړ�����x�N�g��
        Vector2 movement = new Vector2(-1, -1).normalized;
        rb.velocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Wall�^�O�ɓ��������ꍇ�A�����ɏ���
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        // Ground�^�O�܂���Player�^�O�ɓ��������ꍇ�A1�b��ɏ���
        else if (collision.gameObject.CompareTag("Ground") ||
                 collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyAfterDelay(0.5f));
        }
    }

    // �w�肳�ꂽ���Ԍ�ɃI�u�W�F�N�g���\���ɂ���R���[�`��
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
