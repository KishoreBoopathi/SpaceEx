using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBtwShots = 0.5f;
    [SerializeField] float maxTimeBtwShots = 3f;
    [SerializeField] GameObject enemyLaser;
    //[SerializeField] public float projectileSpeed = 10f;
    [SerializeField] int score = 10;
    
    
    //WaveConfig waveConfig;
    GameManager gameManager;
    EnemySpawner enemySpawner;

    public int pickUpCount;
    void Start()
    {
        //waveConfig = FindObjectOfType<WaveConfig>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        gameManager = FindObjectOfType<GameManager>();
        shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
    }

    void Update()
    {
        ManageEnemyShootFreq();
    }

    private void ManageEnemyShootFreq()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBtwShots, maxTimeBtwShots);
        }
    }

    public void ProcessHit(float damageDealer)
    {
        health -= damageDealer;
        if (health <= 0)
        {
            enemySpawner.InstantiatePickUp(transform.position);
            Destroy(gameObject);
            gameManager.GainPoints(score);
            
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemySpawner.enemyLaserProjectileSpeed);
    }
}

