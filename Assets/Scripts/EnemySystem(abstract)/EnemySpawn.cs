using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;  
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;

    private IEnemyFactory enemyFactory;  
    public float MinimumSpawnTime => minimumSpawnTime;
    public float MaximumSpawnTime => maximumSpawnTime;

    private void Awake()
    {
        enemyFactory = new EnemyFactory(enemyPrefab);
    }
    public void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position;
        Enemy enemy = enemyFactory.CreateEnemy(spawnPosition);

        if (enemy != null)
        {
            Debug.Log("Enemy spawned using factory");
        }
    }
}