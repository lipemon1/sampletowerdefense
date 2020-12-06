using System.Collections.Generic;
using SampleTowerDefence.Scripts.Controller.Wave;
using SampleTowerDefence.Scripts.Scriptables;
using SampleTowerDefence.Scripts.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Core
{
    public class LoopController : MonoBehaviour
    {
        public static LoopController Instance { set; get; }
        
        [SerializeField] private List<WaveScriptableObject> waves = new List<WaveScriptableObject>();
        [SerializeField] private Model.Wave currentWave;
        [SerializeField] private int currentWaveIndex;
        private bool _gameStarted;
        
        [Header("Enemies Counter")]
        [SerializeField] private int expectedWaveEnemies;
        [SerializeField] private int currentWaveEnemiesDone;

        [Header("Waves Counter")]
        [SerializeField] private int expectedWaves;
        [SerializeField] private int currentWavesDone;
        
        [Header("References")]
        [SerializeField] private WaveController waveController;
        [SerializeField] private PlayView playView;
        [SerializeField] private WaveView waveView;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void StartGame()
        {
            currentWaveIndex = -1;
            
            expectedWaves = waves.Count;
            currentWavesDone = 0;
            
            StartNextWave();
        }

        public void StartNextWave()
        {
            currentWave = GetNextWave();
            
            expectedWaveEnemies = currentWave.enemies.Count;
            currentWaveEnemiesDone = 0;
            
            waveController.StartWave(currentWave);
        }

        public void NewEnemyDone()
        {
            currentWaveEnemiesDone++;
            
            if(currentWaveEnemiesDone == expectedWaveEnemies)
                EndWave();
        }

        private void EndGame()
        {
            playView.OpenView();
        }

        private void EndWave()
        {
            currentWavesDone++;
            
            if(currentWavesDone == expectedWaves)
                EndGame();
            else
                waveView.OpenView();
        }

        private Model.Wave GetNextWave()
        {
            currentWaveIndex++;
            return waves[currentWaveIndex].GetWaveEnemies();
        }
    }
}
