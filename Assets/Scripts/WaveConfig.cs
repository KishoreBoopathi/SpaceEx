using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public GameObject pathPrefab;
    [SerializeField] public float timeBtwSpawns = 0.5f;
    [SerializeField] public float spawnRandomFactor = 0.3f;
    [SerializeField] public int numberOfEnemies = 5;
    [SerializeField] public float moveSpeed = 2f;
   

    [SerializeField] public bool waitInPath;
     public float waitTimeInMidPath = 6f;

    EnemyPathing enemyPathing;

    /*void start()
    {
        
    }*/

    public GameObject GetEnemyPrefab()    { return enemyPrefab; }

    public List<Transform> GetWayPoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public List<Vector3> GetRandomWayPoints()
    {
        var waveWaypoints = new List<Vector3>();
        int randomWayPointCount = Random.Range(4, 15);
        for(int i = 0; i < randomWayPointCount;i++)
        {
            waveWaypoints.Add(enemyPathing.GetMovementBoundaries());
            //waveWaypoints.Add(Random.Range(Random.Range(xMin, xMax), Random.Range(yMax, yMin));)
        }
        return waveWaypoints;
    }

    public float GetSpawnTime()    { return timeBtwSpawns; }

    public float GetRandomFactor()    { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

    public bool GetWaitInPath() { return waitInPath; }

    public float GetWaitTimeInMidPath() { return waitTimeInMidPath; }

    public IEnumerator pause(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
    }
}
