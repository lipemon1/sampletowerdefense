using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Controller.Pool;
using SampleTowerDefence.Scripts.Controller.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.View
{
    public class OverConstructionDetection : MonoBehaviour
    {
        public static OverConstructionDetection Instance { get; set; }
        
        [SerializeField] private MouseOverConstruction overConstruction;
        [SerializeField] private PrepareConstructionBehaviour constructionToDelete;
        [SerializeField] private bool canDelete;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        private void Update()
        {
            if (overConstruction == null) return;

            if (Input.GetMouseButtonUp(0) && canDelete)
            {
                ViewController.Instance.OpenView(ViewController.ViewType.DeleteDialogView, overConstruction.gameObject.transform.position);
                constructionToDelete = overConstruction.gameObject.GetComponent<PrepareConstructionBehaviour>();
                overConstruction = null;  
            }
        }

        public void NewOverConstruction(MouseOverConstruction construction)
        {
            overConstruction = construction;
        }

        public void DeleteConstruction()
        {
            PoolController.Instance.ReturnConstructionToPool(constructionToDelete);
        }

        public void SetCanDelete(bool value)
        {
            canDelete = value;
        }
    }
}
