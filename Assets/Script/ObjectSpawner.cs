using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // 出現させる物のプレハブをここに設定
    public Vector2 spawnAreaMin; // 出現エリアの左下の座標
    public Vector2 spawnAreaMax; // 出現エリアの右上の座標
    public float spawnInterval = 1.0f; // アイテムがスポーンする間隔（秒）

    void OnTriggerEnter2D(Collider2D other)
    {
        // もしPlayerがぶつかったら
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnItems()); // 物を出現させるコルーチンを開始
        }
    }

    IEnumerator SpawnItems()
    {
        // 出現させる物の数を1から5の間でランダムに決める
        int itemsToSpawn = Random.Range(1, 6);

        for (int i = 0; i < itemsToSpawn; i++)
        {
            // 出現させるランダムな位置を決める
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // 物を出現させる
            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

            // スポーン間隔を待つ
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
