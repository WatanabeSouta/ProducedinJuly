using UnityEngine;
using System.Collections;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject monsterPrefab; // �����X�^�[�̃v���n�u
    public Transform spawnPoint;     // �����X�^�[���X�|�[��������ʒu
    public int numberOfMonsters = 3; // �o���������������X�^�[�̐�
    public float spawnInterval = 0.5f; // �����X�^�[���o��������Ԋu�i�b�j

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnMonsters());
        }
    }

    private IEnumerator SpawnMonsters()
    {
        for (int i = 0; i < numberOfMonsters; i++)
        {
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // �w�肵�����Ԃ����ҋ@����
        }
    }
}
