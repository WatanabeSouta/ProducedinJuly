using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windForce = 10f; // ���̋���

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�v���C���[���͈͂ɓ���܂���");

            // �͂������ăv���C���[���E�ɓ�����
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(new Vector2(10f, 0), ForceMode2D.Impulse); // x�����ɗ͂�������
            }
        }
    }




    private void OnTriggerExit2D(Collider2D other)
    {
        // �G���A����o���Ƃ��̏����i�K�v�ł���΂����ɒǉ��j
    }
}
