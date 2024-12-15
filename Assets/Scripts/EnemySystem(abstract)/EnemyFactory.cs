using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemyFactory
{
    Enemy CreateEnemy(Vector3 spawnPosition);
}
public class EnemyFactory : IEnemyFactory
{
    private GameObject enemyPrefab;

    public EnemyFactory(GameObject prefab)
    {
        enemyPrefab = prefab;
    }
    public Enemy CreateEnemy(Vector3 spawnPosition)
    {
        GameObject enemyInstance = Object.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        return enemyInstance.GetComponent<Enemy>();
    }
}
