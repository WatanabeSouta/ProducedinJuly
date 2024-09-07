using UnityEngine;

public class Monsterspawn : MonoBehaviour
{
    public GameObject monsterPrefab;         // �X�|�[�������郂���X�^�[�̃v���n�u
    public Transform spawnPoint;             // �����X�^�[���X�|�[��������ꏊ

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �Փ˂����I�u�W�F�N�g��Player�^�O�������Ă��邩�m�F
        if (other.CompareTag("Player"))
        {
            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        if (monsterPrefab != null && spawnPoint != null)
        {
            // �����X�^�[���w��̏ꏊ����X�|�[��
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Monster prefab or spawn point is not assigned.");
        }
    }
}
