using System.Collections.Generic;
using SampleTowerDefence.Scripts.Model;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Tower Defense/New wave data", order = 1)]
    public class WaveScriptableObject : ScriptableObject
    {
        [SerializeField] private Model.Wave waveData;

        public Wave GetWaveEnemies()
        {
            return waveData;
        }
    }
}
