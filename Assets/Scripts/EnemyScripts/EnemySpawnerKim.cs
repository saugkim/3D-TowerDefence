using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerKim : MonoBehaviour
{
    public GameObject[] enemyPrefabs = new GameObject[3];
    int waveRandomSize;
    int randomEnemyIndex = 0;

    [SerializeField]
    float spawnRate = 10f;

    public int minRandomSize = 5;
    public int maxRandomSize= 10;

    [SerializeField]   
    float waveInterval = 10f;

    [SerializeField]
    float waitFirstEnemyWave = 2f;
    [SerializeField]
    float waitInfiniteEnemyWave = 5f;

    int waveIndex = 0;

    public WaveDatabase[] waves;

    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnWave());
        yield return StartCoroutine(SpawnWaveInfinity());
    }

    IEnumerator SpawnWaveInfinity()
    {
        yield return new WaitForSeconds(waitInfiniteEnemyWave);

        while(true)
        {
            waveRandomSize = UnityEngine.Random.Range(minRandomSize, maxRandomSize);
            for (int i = 0; i < waveRandomSize; i++)
            {
                randomEnemyIndex = UnityEngine.Random.Range(0, 3);
                SpawnEnemy(enemyPrefabs[randomEnemyIndex]);

                yield return new WaitForSeconds(1f / spawnRate);
            }
            minRandomSize++;
            maxRandomSize++;

            yield return new WaitForSeconds(waveInterval);
            waveInterval *= 0.98f;
        }
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(waitFirstEnemyWave);

        while(waveIndex < waves.Length)
        {
            WaveDatabase wave = waves[waveIndex];

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemyPrefab);
                yield return new WaitForSeconds(1f / wave.rate);
            }
            waveIndex++;
            yield return new WaitForSeconds(waveInterval);
        }
    }

    void SpawnEnemy(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    /*
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startWaitForWave);
        WaveDatabase wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;
        yield return new WaitForSeconds(interval);
      //  interval *= 0.95f;
    }
    */
}