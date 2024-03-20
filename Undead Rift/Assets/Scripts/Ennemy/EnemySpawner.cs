using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    //Variables
    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    private int currentWave;

    //References
    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<Stats_Character> enemyList;


    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING && currentWave != -1)
        {
            if (!EnemiesAreDead())
            {
                return;
            }
            else
            {
                CompletedWave();
            }


        }

        if(waveCountdown <= 0 && currentWave != -1)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }

        }
        else
        {
            if (currentWave != -1)
            {
                waveCountdown -= Time.deltaTime;
            }
            else 
            { 
                waveCountdown = 0; 
            }
            
        }


    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnZombie(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }

        state = SpawnState.WAITING;

        yield break;

    }

    private void SpawnZombie(GameObject enemy)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);

        Transform randomSpawner = spawners[randomInt];

        GameObject newEnemy = Instantiate(enemy, randomSpawner.position, randomSpawner.rotation);
        Stats_Character newEnemyStats = newEnemy.GetComponent<Stats_Character>();
        enemyList.Add(newEnemyStats);
    }

    private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(Stats_Character enemy in enemyList)
        {
            if (enemy.IsDead()){
                i++;
            }
            else
            {
                return false;
            }

        }
        return true;

    }

    private void CompletedWave()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(currentWave +1 > waves.Length-1)
        {
            currentWave = -1;
            Debug.Log("Completed all the waves");
        }
        else
        {
            currentWave++;
        }
       
    }

}
