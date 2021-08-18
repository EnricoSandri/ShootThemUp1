using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveconfigs;
    [SerializeField] int startingWave = 0;
    //[SerializeField] bool looping = false;

    // Use this for initialization
    //IEnumerator Start()
    // for looping the nemies
    void Start()
    {
        //do

        /* yield return */
        StartCoroutine(SpawnAllWaves());
    }
    /* while (looping);
     */
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveconfigs.Count; waveIndex++)
        {
            var currentWave = waveconfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            if(waveIndex == waveconfigs.Count - 2)               ////added so there is time between last wave and boss!!!!!!!!
            {
                yield return new WaitForSeconds(15f);
                Debug.Log("waited fo wave");
            }
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimebetweenSpawn());
        }
    }


}

