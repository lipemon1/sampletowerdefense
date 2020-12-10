using System;
using System.Collections;
using System.Collections.Generic;
using SampleTowerDefence.Scripts.Behaviours.Enemy;
using SampleTowerDefence.Scripts.Controller.Enemy;
using SampleTowerDefence.Scripts.Controller.Pool;
using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SampleTowerDefence.Scripts.Controller.Wave
{
    public class WaveController : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float delayBetweenEnemies;
        [SerializeField] private float delayBetweenSameSpawn;
        [SerializeField] private int maxEnemiesPerSpawn;

        [Header("Scriptables References")]
        [SerializeField] private EnemyScriptableObject normalEnemyData;
        [SerializeField] private EnemyScriptableObject strongEnemyData;
        
        [Header("Data for Running Wave")]
        [HideInInspector] private List<Model.Wave.EnemyType> _enemiesTypesToSpawn;
        [HideInInspector] private bool _waveSpawning;
        
        //waitforseconds to be used on wave spawning
        private WaitForSeconds _spawnDelay;
        private WaitForSeconds _delayOnSameSpawn;

        private void Awake()
        {
            _spawnDelay = new WaitForSeconds(delayBetweenEnemies);
            _delayOnSameSpawn = new WaitForSeconds(delayBetweenSameSpawn);
        }

        [ContextMenu("Start Wave Spawn")]
        public void StartWave(Model.Wave wave)
        {
            _enemiesTypesToSpawn = new List<Model.Wave.EnemyType>();
            _enemiesTypesToSpawn.AddRange(wave.enemies);
            
            _waveSpawning = true;
            StartCoroutine(SpawnWave(wave));
        }

        [ContextMenu("Stop Wave Spawn")]
        public void StopWave()
        {
            _waveSpawning = false;
        }

        private IEnumerator SpawnWave(Model.Wave wave)
        {
            while (_waveSpawning && _enemiesTypesToSpawn.Count > 0)
            {
                yield return _spawnDelay;

                var enemiesAmount = AmountOfEnenmiesToSpawn();

                for (int i = 0; i < enemiesAmount; i++)
                {
                    var newEnemy = PoolController.Instance.GetAvailableEnemy();
                    newEnemy.transform.position = wave.startPos;
                    newEnemy.SpawnEnemy(GetEnemyData(_enemiesTypesToSpawn.PopAt(0)));

                    yield return _delayOnSameSpawn;
                }

                if (_enemiesTypesToSpawn.Count <= 0)
                {
                    StopWave();
                    yield return null;
                }   
            }
        }

        private int AmountOfEnenmiesToSpawn()
        {
            var maxEnemyToSpawn = maxEnemiesPerSpawn;
            
            if (maxEnemiesPerSpawn > _enemiesTypesToSpawn.Count)
                maxEnemyToSpawn = _enemiesTypesToSpawn.Count;
            
            return Random.Range(1, maxEnemyToSpawn);
        }

        private Model.Enemy GetEnemyData(Model.Wave.EnemyType enemyType)
        {
            Model.Enemy newEnemy = null;
            
            switch (enemyType)
            {
                case Model.Wave.EnemyType.Normal:
                    newEnemy = new Model.Enemy(normalEnemyData.GetEnemyData());
                    break;
                case Model.Wave.EnemyType.Strong:
                    newEnemy = new Model.Enemy(strongEnemyData.GetEnemyData());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }

            return newEnemy;
        }
    }
}
