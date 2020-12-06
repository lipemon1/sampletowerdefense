using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.Wave;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class PlayView : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private GameObject viewObject;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
        }

        private void PlayButtonClicked()
        {
            viewObject.SetActive(false);
            LoopController.Instance.StartGame();
        }

        public void OpenView()
        {
            viewObject.SetActive(true);
        }
    }
}
