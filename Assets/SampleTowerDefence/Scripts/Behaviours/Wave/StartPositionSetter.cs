using System.Collections.Generic;
using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Wave
{
    public class StartPositionSetter : MonoBehaviour
    {
        [SerializeField] private List<Transform> startPositions = new List<Transform>();
        
        public void SetStartPositionOnWaves(List<WaveScriptableObject> waveScriptableObjects)
        {
            if(startPositions.Count != waveScriptableObjects.Count)
                Debug.LogError("Amount of transform and waves are differents. Set correctly before keep going");
            
            for (var i = 0; i < waveScriptableObjects.Count; i++)
                waveScriptableObjects[i].SetStartPosition(startPositions[i].position);
        }
    }
}
