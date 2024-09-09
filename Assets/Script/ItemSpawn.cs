using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemPrefab; // �o�������镨�̃v���n�u�������ɐݒ�
    public int numberOfItems = 3; // �o�������镨�̐�
    public Vector2 spawnAreaMin; // �o���G���A�̍����̍��W
    public Vector2 spawnAreaMax; // �o���G���A�̉E��̍��W

    void OnTriggerEnter2D(Collider2D other)
    {
        // ����Player���Ԃ�������
        if (other.CompareTag("Player"))
        {
            SpawnItems(); // �����o��������
        }
    }

    void SpawnItems()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            // �o�������郉���_���Ȉʒu�����߂�
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // �����o��������
            GameObject spawnedItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
            spawnedItem.tag = "Isi"; // �^�O��ݒ�
        }
    }
}
