using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    public float MinimumSpawnTime => minimumSpawnTime;
    public float MaximumSpawnTime => maximumSpawnTime;
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Debug.Log("Spawned Enemy");
    }
}
