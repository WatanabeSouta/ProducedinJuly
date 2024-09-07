using UnityEngine;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject monsterPrefab; // モンスターのプレハブ
    public Transform spawnPoint;     // モンスターをスポーンさせる位置
    public int numberOfMonsters = 3; // 出現させたいモンスターの数

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnMonsters();
        }
    }

    private void SpawnMonsters()
    {
        // 指定した数だけモンスターをスポーンさせる
        for (int i = 0; i < numberOfMonsters; i++)
        {
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
