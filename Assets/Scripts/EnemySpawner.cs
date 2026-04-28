using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false; 
    [SerializeField] public float enemyLaserProjectileSpeed = 10f;
    [SerializeField] GameObject healthUp;
    
    GameObject gameManager;
    //Enemy enemy;

    public int waveCount = 0;
    int waveLabel = 0;
    int waveIndex = 0;
    int pickUpCount = 0;

    // Use this for initialization
    IEnumerator Start () {
        gameManager = GameObject.Find("GameManager");
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
        
	}

    private IEnumerator SpawnAllWaves()
    {
        
        for (waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            waveCount++;
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            currentWave.moveSpeed += 0.2f;
            if(waveCount > waveLabel+10)
            {
                enemyLaserProjectileSpeed += 0.1f;
                waveLabel = waveCount;
            }
        }
        
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i=0;i<waveConfig.GetNumberOfEnemies();i++)
        {
            if(waveConfig.GetWaitInPath() && i>0)
            { 
                yield return new WaitForSeconds(waveConfig.GetWaitTimeInMidPath());
            }
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(Random.Range(0.5f,waveConfig.GetSpawnTime()));
        }
    }

    private void FixedUpdate()
    {
        gameManager.GetComponent<GameManager>().wave = waveCount;
    }

    public float GetLaserProjectileSpeed()
    {
        return enemyLaserProjectileSpeed;
    }

    public void InstantiatePickUp(Vector3 enemyPosition)
    {
        if ((waveCount - pickUpCount) > 50)
        {
            pickUpCount = waveCount;
            Instantiate(healthUp, enemyPosition, Quaternion.identity);
        }
    }
}
