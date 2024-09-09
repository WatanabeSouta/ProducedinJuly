using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemPrefab; // 出現させる物のプレハブをここに設定
    public int numberOfItems = 3; // 出現させる物の数
    public Vector2 spawnAreaMin; // 出現エリアの左下の座標
    public Vector2 spawnAreaMax; // 出現エリアの右上の座標

    void OnTriggerEnter2D(Collider2D other)
    {
        // もしPlayerがぶつかったら
        if (other.CompareTag("Player"))
        {
            SpawnItems(); // 物を出現させる
        }
    }

    void SpawnItems()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            // 出現させるランダムな位置を決める
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // 物を出現させる
            GameObject spawnedItem = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
            spawnedItem.tag = "Isi"; // タグを設定
        }
    }
}
