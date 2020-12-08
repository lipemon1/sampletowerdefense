using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Controller.Core;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class WaveView : ViewBehaviour
    {
        [SerializeField] private Button nextWaveButton;
        
        private void Awake()
        {
            nextWaveButton.onClick.AddListener(WaveButtonClicked);
        }
        
        private void WaveButtonClicked()
        {
            CloseView();
            LoopController.Instance.StartNextWave();
        }
    }
}
