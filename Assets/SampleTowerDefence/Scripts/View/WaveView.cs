using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.View;
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
            ViewController.Instance.OpenView(ViewController.ViewType.GameView);
            LoopController.Instance.StartNextWave();
        }
    }
}
