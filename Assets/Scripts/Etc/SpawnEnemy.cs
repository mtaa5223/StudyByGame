using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] Mob;
    [SerializeField] private Transform[] SpawnPoint;
    
    private int lastMobIndex = -1; // 마지막에 스폰된 몬스터 인덱스 추적
    private List<GameObject> spawnedMobs = new List<GameObject>(); // 생성된 몹들을 추적하는 리스트

    // 오브젝트가 활성화될 때마다 호출
    private void OnEnable()
    {
        SpawnAllMobs();
    }

    // 오브젝트가 비활성화될 때마다 호출
    private void OnDisable()
    {
        DestroyAllMobs();
    }

    // 모든 몹 생성
    private void SpawnAllMobs()
    {
        // 이전에 생성된 몹들이 있다면 먼저 제거
        DestroyAllMobs();
        
        // 사용 가능한 스폰 포인트 리스트 생성
        List<Transform> availableSpawnPoints = new List<Transform>(SpawnPoint);
        
        // 몹의 갯수 정의
        int LengthMob = Mob.Length;
        int SpawnCount = Random.Range(1, SpawnPoint.Length + 1);
        
        // 마지막 몹 인덱스 초기화 (새로 시작할 때)
        lastMobIndex = -1;

        for (int i = 0; i < SpawnCount && availableSpawnPoints.Count > 0; i++)
        {
            SpawnMob(availableSpawnPoints, LengthMob);
        }
    }

    // 모든 몹 제거
    private void DestroyAllMobs()
    {
        // 생성된 몹들을 모두 제거
        foreach (GameObject mob in spawnedMobs)
        {
            if (mob != null) // null 체크 (이미 파괴된 경우 대비)
            {
                Destroy(mob);
            }
        }
        
        // 리스트 초기화
        spawnedMobs.Clear();
        
        // 마지막 몹 인덱스 초기화
        lastMobIndex = -1;
    }

    // 랜덤으로 위치와 몹을 생성하고 사용한 스폰포인트 제거
    private void SpawnMob(List<Transform> availablePoints, int MobLength)
    {
        int MobIndex;
        
        // 같은 몬스터가 연속으로 나오지 않게 하기
        if (MobLength > 1 && lastMobIndex != -1)
        {
            do
            {
                MobIndex = Random.Range(0, MobLength);
            } while (MobIndex == lastMobIndex);
        }
        else
        {
            MobIndex = Random.Range(0, MobLength);
        }
        
        int SpawnIndex = Random.Range(0, availablePoints.Count);
        Transform selectedSpawnPoint = availablePoints[SpawnIndex];
        
        // 몹 생성
        GameObject spawnedMob = Instantiate(Mob[MobIndex], selectedSpawnPoint);
        
        // 생성된 몹을 리스트에 추가 (추적용)
        spawnedMobs.Add(spawnedMob);
        
        // 마지막 몬스터 인덱스 업데이트
        lastMobIndex = MobIndex;
        
        // 사용한 스폰 포인트를 리스트에서 제거
        availablePoints.RemoveAt(SpawnIndex);
    }
}
