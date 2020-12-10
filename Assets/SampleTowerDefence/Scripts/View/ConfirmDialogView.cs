﻿using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Controller.Core;
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
            CloseView();
        }

        private void OnConfirmButtonClicked()
        {
            constructorBehaviour.PlaceConstruction();
            CloseView();
        }

        private void OpenView()
        {
            base.OpenView();
            LoopController.OnWaveEnd += OnCancelButtonClicked;
        }

        private void CloseView()
        {
            constructorBehaviour.SetConfirming(false);
            ViewController.Instance.OpenView(ViewController.ViewType.GameView);
            
            LoopController.OnWaveEnd -= OnCancelButtonClicked;
        }
    }
}
