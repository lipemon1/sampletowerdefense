using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Controller.View;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class DeleteDialogView : ViewBehaviour
    {
        [SerializeField] private Button cancelDeleteButton;
        [SerializeField] private Button confirmDeleteButton;

        [SerializeField] private ConstructorBehaviour constructorBehaviour;

        private void Awake()
        {
            cancelDeleteButton.onClick.AddListener(OnCancelDeleteButtonClicked);
            confirmDeleteButton.onClick.AddListener(OnConfirmDeleteButtonClicked);
        }

        private void OnCancelDeleteButtonClicked()
        {
            constructorBehaviour.SetConfirming(false);
            CloseView();
        }

        private void OnConfirmDeleteButtonClicked()
        {
            OverConstructionDetection.Instance.DeleteConstruction();
            constructorBehaviour.SetConfirming(false);
            CloseView();
        }

        private void CloseView()
        {
            ViewController.Instance.OpenView(ViewController.ViewType.GameView);
        }
    }
}
