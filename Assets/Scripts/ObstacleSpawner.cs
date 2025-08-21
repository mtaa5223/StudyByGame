using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // ��ֹ� �����յ�
    public Transform spawnPoint;         // �� ���� ��ġ
    public float spawnChance = 0.5f;     // ��ֹ��� ���� Ȯ��

    public void SpawnObstacles()
    {
        if (Random.value < spawnChance)
        {
            int rand = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[rand], spawnPoint.position, Quaternion.identity);
        }
    }
}
