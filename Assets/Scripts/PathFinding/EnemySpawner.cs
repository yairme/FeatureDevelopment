using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int EnemiesAlive = 0;

    public Waves[] wave;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 6f;
    private bool gameEnd = true;

    public int waveNumber = 0;

    void Update()
    {
        if (EnemiesAlive <= -1)
        {
            EnemiesAlive = 0;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            if (gameEnd)
                return;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
    }

    IEnumerator SpawnWave()
    {
        Waves waves = wave[waveNumber];

        for (int i = 0; i < waves.Enemy.Length / waves.count; i++)
        {
            for (int j = 0; j < waves.count; j++)
            {
                SpawnEnemy(waves.Enemy[j]);
                yield return new WaitForSeconds(1f / waves.spawnTime);
                if (waveNumber >= wave.Length - 1 && EnemiesAlive <= 0)
                {
                    Debug.Log("Game Over");
                    this.enabled = false;
                }
            }
            yield return new WaitForSeconds(1f / waves.spawnTime);
        }
        waveNumber++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
