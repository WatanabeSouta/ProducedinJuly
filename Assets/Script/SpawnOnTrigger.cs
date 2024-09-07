using UnityEngine;

public class Monsterspawn : MonoBehaviour
{
    public GameObject monsterPrefab;         // スポーンさせるモンスターのプレハブ
    public Transform spawnPoint;             // モンスターをスポーンさせる場所

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトがPlayerタグを持っているか確認
        if (other.CompareTag("Player"))
        {
            SpawnMonster();
        }
    }

    private void SpawnMonster()
    {
        if (monsterPrefab != null && spawnPoint != null)
        {
            // モンスターを指定の場所からスポーン
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Monster prefab or spawn point is not assigned.");
        }
    }
}
