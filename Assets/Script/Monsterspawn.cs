using UnityEngine;
using System.Collections;

public class Monsterspawn: MonoBehaviour
{
    public GameObject player;                // プレイヤーオブジェクト
    public GameObject monsterPrefab;         // モンスターのプレハブ
    public Transform[] spawnPoints;          // モンスターのスポーンポイント
    public float triggerDistance = 10f;      // トリガーの距離
    public float spawnInterval = 2f;         // モンスターを1体ずつスポーンさせる間隔

    private bool isSpawning = false;         // スポーン中かどうかをチェック

    private void Update()
    {
        // プレイヤーとの距離を計算
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // プレイヤーが指定の距離内にいる場合、スポーン処理を開始
        if (distance <= triggerDistance && !isSpawning)
        {
            StartCoroutine(SpawnMonsters());
        }
    }

    private IEnumerator SpawnMonsters()
    {
        isSpawning = true;

        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // 次のモンスターをスポーンさせるまで待機
        }

        isSpawning = false; // スポーン処理が完了
    }
}