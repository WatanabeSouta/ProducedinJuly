using UnityEngine;

public class HosiSpawn : MonoBehaviour
{
    public GameObject monsterPrefab; // スポーンさせたいモンスターのプレハブ
    public Transform spawnPoint; // モンスターをスポーンさせる位置

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーがトリガーゾーンに入ったときにモンスターをスポーンさせる
            Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
