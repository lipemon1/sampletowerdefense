﻿using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Controller.View;
using UnityEngine;
using UnityEngine.UI;

namespace SampleTowerDefence.Scripts.View
{
    public class ConfirmDialogView : ViewBehaviour
    {
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button confirmButton;

        [SerializeField] private ConstructorBehaviour constructorBehaviour;

        private void Awake()
        {
            cancelButton.onClick.AddListener(OnCancelButtonClicked);
            confirmButton.onClick.AddListener(OnConfirmButtonClicked);
        }

        private void OnCancelButtonClicked()
        {
            constructorBehaviour.CancelPlacementConstruction();
            constructorBehaviour.SetConfirming(false);
            CloseView();
        }

        private void OnConfirmButtonClicked()
        {
            constructorBehaviour.PlaceConstruction();
            constructorBehaviour.SetConfirming(false);
            CloseView();
        }

        private void CloseView()
        {
            ViewController.Instance.OpenView(ViewController.ViewType.GameView);
        }
    }
}
