using System;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject bigZombiePrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform enemySpawnPosition;
    [SerializeField] private float offset = 8f;

    private void Start()
    {
        Enemy enemy1 = CreateEnemy("Zombie");
        Enemy enemy2 = CreateEnemy("Zombie");
        Enemy enemy3 = CreateEnemy("BigZombie");
        Enemy enemy4 = CreateEnemy("BigZombie");
        
        enemy1.Attack();
        enemy2.Attack();
        enemy3.Attack();
        enemy4.Attack();
    }

    private Enemy CreateEnemy(string enemy)
    {
        GameObject spawnedEnemy = Instantiate(GetEnemyPrefab(enemy), GetRandomPosition(), Quaternion.identity);
        var enemyComponent = spawnedEnemy.GetComponent<Enemy>();
        enemyComponent.Init(playerTransform);
        return enemyComponent;
    }

    private GameObject GetEnemyPrefab(string enemy)
    {
        GameObject enemyToSpawn;

        switch (enemy)
        {
            case "Zombie":
                enemyToSpawn = zombiePrefab;
                break;
            case "BigZombie":
                enemyToSpawn = bigZombiePrefab;
                break;
            default:
                enemyToSpawn = zombiePrefab;
                break;
        }

        return enemyToSpawn;
    }

    private Vector3 GetRandomPosition()
    {
        float randomX = UnityEngine.Random.Range(-offset, offset);
        float randomZ = UnityEngine.Random.Range(-offset, offset);
        return new Vector3(randomX, 0f, randomZ) + enemySpawnPosition.position;
    }
}
