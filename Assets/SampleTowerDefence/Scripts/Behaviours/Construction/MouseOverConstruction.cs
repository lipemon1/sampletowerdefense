using SampleTowerDefence.Scripts.Behaviours.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction
{
    public class MouseOverConstruction : MonoBehaviour
    {   
        private void OnMouseOver()
        {
            OverConstructionDetection.Instance.NewOverConstruction(this);
        }

        private void OnMouseExit()
        {
            OverConstructionDetection.Instance.NewOverConstruction(null);
        }
    }
}
