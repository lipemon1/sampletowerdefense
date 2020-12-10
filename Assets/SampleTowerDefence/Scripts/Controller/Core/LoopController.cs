using System.Collections.Generic;
using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.Wave;
using SampleTowerDefence.Scripts.Controller.View;
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
        
        [Header("Enemies Counter")]
        [SerializeField] private int expectedWaveEnemies;
        [SerializeField] private int currentWaveEnemiesDone;

        [Header("Waves Counter")]
        [SerializeField] private int expectedWaves;
        [SerializeField] private int currentWavesDone;
        
        [Header("References")]
        [HideInInspector] private WaveController _waveController;
        [SerializeField] private ConstructorBehaviour constructorBehaviour;
        [HideInInspector] private StartPositionSetter _startPositionSetter;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            _waveController = GetComponent<WaveController>();
            _startPositionSetter = GetComponent<StartPositionSetter>();
        }

        public void StartGame()
        {
            _startPositionSetter.SetStartPositionOnWaves(waves);
            
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
            
            _waveController.StartWave(currentWave);
        }

        public void NewEnemyDone()
        {
            currentWaveEnemiesDone++;
            
            if(currentWaveEnemiesDone == expectedWaveEnemies)
                EndWave();
        }

        private void EndGame()
        {
            ViewController.Instance.OpenView(ViewController.ViewType.PlayView);
        }

        private void EndWave()
        {
            constructorBehaviour.DisableConstruction();
            
            currentWavesDone++;
            
            if(currentWavesDone == expectedWaves)
                EndGame();
            else
                ViewController.Instance.OpenView(ViewController.ViewType.WaveView);
        }

        private Model.Wave GetNextWave()
        {
            currentWaveIndex++;
            return waves[currentWaveIndex].GetWaveEnemies();
        }
    }
}
