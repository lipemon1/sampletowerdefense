using SampleTowerDefence.Scripts.Controller.Core;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class WaveView : MonoBehaviour
    {
        [SerializeField] private GameObject viewObject;
        [SerializeField] private Button nextWaveButton;
        
        private void Awake()
        {
            nextWaveButton.onClick.AddListener(WaveButtonClicked);
        }
        
        public void OpenView()
        {
            viewObject.gameObject.SetActive(true);
        }

        private void CloseView()
        {
            viewObject.gameObject.SetActive(false);
        }
        
        private void WaveButtonClicked()
        {
            viewObject.SetActive(false);
            LoopController.Instance.StartNextWave();
        }
    }
}
