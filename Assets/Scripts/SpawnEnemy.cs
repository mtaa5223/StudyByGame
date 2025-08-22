using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]private GameObject[] Mob;
    [SerializeField]private Transform[] SpawnPoint;


    private void Awake()
    {
        int LengthSpawn = SpawnPoint.Length;
        int LengthMob = Mob.Length;
        
        SpawnMob(LengthSpawn, LengthMob);
    }



    private void SpawnMob(int PointLength, int MobLength)
    {
        int MobIndex = Random.Range(0, MobLength);
        int SpawnIndex = Random.Range(0, PointLength);

        Instantiate(Mob[MobIndex], SpawnPoint[SpawnIndex]);
    }
}
