using System.Collections.Generic;
using SampleTowerDefence.Scripts.Behaviours.Construction;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Construction
{
    public class ConstructionPoolController : MonoBehaviour
    {
        [SerializeField] private List<PrepareConstructionBehaviour> constructionsAvailable = new List<PrepareConstructionBehaviour>();

        public PrepareConstructionBehaviour GetAvailableConstruction()
        {
            return constructionsAvailable?.Count > 0 ? constructionsAvailable.PopAt(0) : null;
        }
    }
}