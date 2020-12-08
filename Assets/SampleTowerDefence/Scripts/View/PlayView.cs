using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.Wave;
using SampleTowerDefence.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class PlayView : ViewBehaviour
    {
        [SerializeField] private Button playButton;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
        }

        private void PlayButtonClicked()
        {
            CloseView();
            
            LoopController.Instance.StartGame();
        }
    }
}
