using UnityEngine;
using System.Collections;

public class Monsterspawn: MonoBehaviour
{
    public GameObject player;                // �v���C���[�I�u�W�F�N�g
    public GameObject monsterPrefab;         // �����X�^�[�̃v���n�u
    public Transform[] spawnPoints;          // �����X�^�[�̃X�|�[���|�C���g
    public float triggerDistance = 10f;      // �g���K�[�̋���
    public float spawnInterval = 2f;         // �����X�^�[��1�̂��X�|�[��������Ԋu

    private bool isSpawning = false;         // �X�|�[�������ǂ������`�F�b�N

    private void Update()
    {
        // �v���C���[�Ƃ̋������v�Z
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // �v���C���[���w��̋������ɂ���ꍇ�A�X�|�[���������J�n
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
            yield return new WaitForSeconds(spawnInterval); // ���̃����X�^�[���X�|�[��������܂őҋ@
        }

        isSpawning = false; // �X�|�[������������
    }
}