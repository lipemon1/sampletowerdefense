using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.View;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class GameView : ViewBehaviour
    {
        [SerializeField] private Button barrierButton;
        [SerializeField] private Button towerButton;

        [SerializeField] private ConstructorBehaviour constructorBehaviour;
        
        private void Awake()
        {
            barrierButton.onClick.AddListener(OnBarrierClicked);
            towerButton.onClick.AddListener(OnTowerClicked);
        }

        private void OnTowerClicked()
        {
            constructorBehaviour.EnableConstruction(ConstructorBehaviour.ConstructionMode.Tower);
        }

        private void OnBarrierClicked()
        {
            constructorBehaviour.EnableConstruction(ConstructorBehaviour.ConstructionMode.Barrier);
        }
    }
}
