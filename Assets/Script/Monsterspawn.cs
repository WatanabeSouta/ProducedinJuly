using UnityEngine;
using System.Collections;

public class SpawnOnTrigger : MonoBehaviour
{
    public GameObject monsterPrefab; // モンスターのプレハブ
    public Transform spawnPoint;     // モンスターをスポーンさせる位置
    public int numberOfMonsters = 3; // 出現させたいモンスターの数
    public float spawnInterval = 0.5f; // モンスターを出現させる間隔（秒）

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
            yield return new WaitForSeconds(spawnInterval); // 指定した時間だけ待機する
        }
    }
}
