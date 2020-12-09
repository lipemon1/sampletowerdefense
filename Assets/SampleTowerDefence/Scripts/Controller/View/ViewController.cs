using System;
using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Behaviours.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.View
{
    public class ViewController : MonoBehaviour
    {
        public enum ViewType
        {
            Undefined,
            PlayView,
            GameView,
            WaveView,
            ConfirmDialogView,
            DeleteDialogView
        }
        
        public static ViewController Instance { get; set; }

        [Header("Start")]
        [SerializeField] private ViewType startView;
        
        [Header("Debug Views")]
        [SerializeField] private ViewType curView;
        [SerializeField] private ViewType lastView;
        
        [Header("Views To Handle")]
        [SerializeField] private List<ViewBehaviour> views = new List<ViewBehaviour>();
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
            
            OpenView(startView);
        }

        public void OpenView(ViewType viewType)
        {
            PrepareOpenView(viewType);
            views.FirstOrDefault(v => v.GetViewType() == viewType)?.OpenView();
        }
        
        public void OpenView(ViewType viewType, Vector3 posToOpen)
        {
            PrepareOpenView(viewType);
            views.FirstOrDefault(v => v.GetViewType() == viewType)?.OpenView(posToOpen);
        }

        private void PrepareOpenView(ViewType viewType)
        {
            lastView = curView;
            curView = viewType;
            
            //Checking for not configured view
            if(viewType == ViewType.Undefined)
                Debug.LogError("View not defined");

            //Closing every other view
            foreach (var view in views)
                if (view.GetViewType() != viewType) view.CloseView();
        }

        public void CloseView(ViewType viewType)
        {
            views?.FirstOrDefault(v => v.GetViewType() == viewType)?.CloseView();
        }
    }
}
