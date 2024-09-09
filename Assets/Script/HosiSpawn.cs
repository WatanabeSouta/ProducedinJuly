using UnityEngine;

public class HosiSpawn : MonoBehaviour
{
    public GameObject monsterPrefab; // �X�|�[���������������X�^�[�̃v���n�u
    public Transform spawnPoint; // �����X�^�[���X�|�[��������ʒu

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[���g���K�[�]�[���ɓ������Ƃ��Ƀ����X�^�[���X�|�[��������
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
