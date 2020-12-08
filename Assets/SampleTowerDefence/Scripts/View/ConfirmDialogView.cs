using SampleTowerDefence.Scripts.Behaviours.Construction;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class ConfirmDialogView : MonoBehaviour
    {
        [SerializeField] private GameObject viewObject;

        [SerializeField] private Button cancelButton;
        [SerializeField] private Button confirmButton;

        [SerializeField] private ConstructorBehaviour constructorBehaviour;

        [SerializeField] private Vector3 posOffset;

        [SerializeField] private GameView gameView;

        private void Awake()
        {
            cancelButton.onClick.AddListener(OnCancelButtonClicked);
            confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        }

        private void OnCancelButtonClicked()
        {
            constructorBehaviour.CancelPlacementConstruction();
            
            CloseView();
        }

        private void OnConfirmButtonClicked()
        {
            constructorBehaviour.PlaceConstruction();
            
            CloseView();
        }

        public void OpenView(Vector3 posToOpen)
        {
            posToOpen += posOffset;
            
            viewObject.transform.position = posToOpen;
            
            constructorBehaviour.SetConfirming(true);
            
            viewObject.SetActive(true);
        }

        private void CloseView()
        {
            gameView.OpenView();
            
            constructorBehaviour.SetConfirming(false);
            
            viewObject.SetActive(false);
        }
    }
}
