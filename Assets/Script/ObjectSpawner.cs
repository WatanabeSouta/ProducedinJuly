using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // �o�������镨�̃v���n�u�������ɐݒ�
    public Vector2 spawnAreaMin; // �o���G���A�̍����̍��W
    public Vector2 spawnAreaMax; // �o���G���A�̉E��̍��W
    public float spawnInterval = 1.0f; // �A�C�e�����X�|�[������Ԋu�i�b�j

    void OnTriggerEnter2D(Collider2D other)
    {
        // ����Player���Ԃ�������
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnItems()); // �����o��������R���[�`�����J�n
        }
    }

    IEnumerator SpawnItems()
    {
        // �o�������镨�̐���1����5�̊ԂŃ����_���Ɍ��߂�
        int itemsToSpawn = Random.Range(1, 6);

        for (int i = 0; i < itemsToSpawn; i++)
        {
            // �o�������郉���_���Ȉʒu�����߂�
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // �����o��������
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

            // �X�|�[���Ԋu��҂�
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
