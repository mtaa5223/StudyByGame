using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 장애물 프리팹들
    public Transform spawnPoint;         // 땅 기준 위치
    public float spawnChance = 0.5f;     // 장애물이 나올 확률

    public void SpawnObstacles()
    {
        if (Random.value < spawnChance)
        {
            int rand = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[rand], spawnPoint.position, Quaternion.identity);
        }
    }
}
