using SampleTowerDefence.Scripts.Behaviours.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction
{
    public class MouseOverConstruction : MonoBehaviour
    {
        [SerializeField] private MouseOverConstruction mouseOverConstruction;
        
        private void OnMouseEnter()
        {
            OverConstructionDetection.Instance.NewOverConstruction(mouseOverConstruction);
        }

        private void OnMouseExit()
        {
            OverConstructionDetection.Instance.NewOverConstruction(mouseOverConstruction);
        }
    }
}
