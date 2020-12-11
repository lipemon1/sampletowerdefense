using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.View;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class GameView : ViewBehaviour
    {
        [SerializeField] private Button barrierButton;
        [SerializeField] private Button singleTargetTowerButton;
        [SerializeField] private Button areaTargetTowerButton;
        [SerializeField] private Button slowTargetTowerButton;

        [SerializeField] private ConstructorBehaviour constructorBehaviour;
        
        private void Awake()
        {
            barrierButton.onClick.AddListener(OnBarrierClicked);
            singleTargetTowerButton.onClick.AddListener(OnSingleTargetTowerClicked);
            areaTargetTowerButton.onClick.AddListener(OnAreaTargetTowerClicked);
            slowTargetTowerButton.onClick.AddListener(OnSlowTargetTowerClicked);
        }

        private void OnSingleTargetTowerClicked()
        {
            constructorBehaviour.EnableConstruction(Model.Construction.ConstructionType.SingleTargetTower);
        }
        
        private void OnAreaTargetTowerClicked()
        {
            constructorBehaviour.EnableConstruction(Model.Construction.ConstructionType.AreaDamageTower);
        }
        
        private void OnSlowTargetTowerClicked()
        {
            constructorBehaviour.EnableConstruction(Model.Construction.ConstructionType.SlowTargetTower);
        }

        private void OnBarrierClicked()
        {
            constructorBehaviour.EnableConstruction(Model.Construction.ConstructionType.Barrier);
        }
    }
}
