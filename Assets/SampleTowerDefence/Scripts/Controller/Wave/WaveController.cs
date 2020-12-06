using System;
using System.Collections;
using System.Collections.Generic;
using SampleTowerDefence.Scripts.Controller.Enemy;
using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Wave
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private Transform spawnTransform;
        [SerializeField] private List<Model.Wave.EnemyType> enemiesTypesToSpawn;
        [SerializeField] private float delayBetweenEnemies;
        [SerializeField] private bool waveSpawning;

        [SerializeField] private EnemyScriptableObject normalEnemyData;
        [SerializeField] private EnemyScriptableObject strongEnemyData;

        private WaitForSeconds _spawnDelay;

        private void Awake()
        {
            _spawnDelay = new WaitForSeconds(delayBetweenEnemies);
        }

        [ContextMenu("Start Wave Spawn")]
        public void StartWave(Model.Wave wave)
        {
            enemiesTypesToSpawn = new List<Model.Wave.EnemyType>();
            enemiesTypesToSpawn.AddRange(wave.enemies);
            
            waveSpawning = true;
            StartCoroutine(SpawnWave());
        }

        [ContextMenu("Stop Wave Spawn")]
        public void StopWave()
        {
            waveSpawning = false;
            Debug.Log("Finish Wave Spawn");
        }

        private IEnumerator SpawnWave()
        {
            while (waveSpawning && enemiesTypesToSpawn.Count > 0)
            {
                yield return _spawnDelay;
                
                var enemy = EnemyPoolController.Instance.GetAvailableEnemy();
                
                enemy.transform.position = spawnTransform.position;
                enemy.SpawnEnemy(GetEnemyData(enemiesTypesToSpawn.PopAt(0)));

                if (enemiesTypesToSpawn.Count <= 0)
                {
                    StopWave();
                    yield return null;
                }   
            }
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
