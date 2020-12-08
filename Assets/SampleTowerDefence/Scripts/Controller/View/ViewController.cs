using System;
using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Behaviours.View;
using SampleTowerDefence.Scripts.Model;
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
            WaveView
        }
        
        public static ViewController Instance { get; set; }

        [SerializeField] private List<ViewBehaviour> views = new List<ViewBehaviour>();
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        public void OpenView(ViewType viewTypeWanted)
        {
            if(viewTypeWanted == ViewType.Undefined)
                Debug.LogError("View not defined");
            
            foreach (var view in views)
                view.CloseView();
            
            views.FirstOrDefault(v => v.GetViewType() == viewTypeWanted)?.OpenView();
        }
    }
}
