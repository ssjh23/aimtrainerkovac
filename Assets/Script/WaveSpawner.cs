using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState{ SPAWNING, WAITING, COUNTING };
    
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown =1f;
    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawnpoints referenced");
        }
        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //CHeck if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begins new round
                WaveCompleted();
                
                return;
            }
            else
            {
                return;
            }

        }

        if (waveCountdown <= 0)
        {
            //Spawns wave when countdown is 0 & Checks if spawn boolean == true//
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave ( waves[nextWave]));
            }
            
        }
        else
        {
            //Timer goes down by time, not by frames//
            waveCountdown-= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        // If current wave count > max wave
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE! Looping..");
        }
        else
        {
            nextWave++;
        }
        
    }
    bool EnemyIsAlive()
    //Check if enemy is alive
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown<= 0f)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
       

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        //Enemy count follows wave number
        for (int i = 0; i < _wave.count; i++)
        {
           SpawnEnemy(_wave.enemy);
           yield return new WaitForSeconds( 1f/_wave.rate);

        }

        //Spawn

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = spawnPoints[ Random.Range(0,spawnPoints.Length)];
        Instantiate (_enemy , _sp.position, _sp.rotation);
        
    }
}
