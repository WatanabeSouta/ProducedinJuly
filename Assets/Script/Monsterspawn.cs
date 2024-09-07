using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject monsterPrefab; // �����X�^�[�̃v���n�u
    public Transform spawnPoint;     // �����X�^�[���X�|�[��������ʒu
    public int numberOfMonsters = 3; // �o���������������X�^�[�̐�

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnMonsters();
        }
    }

    private void SpawnMonsters()
    {
        // �w�肵�������������X�^�[���X�|�[��������
        for (int i = 0; i < numberOfMonsters; i++)
        {
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
