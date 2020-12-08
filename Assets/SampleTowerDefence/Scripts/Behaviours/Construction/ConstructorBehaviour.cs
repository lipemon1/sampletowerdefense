using System;
using SampleTowerDefence.Scripts.Controller.Construction;
using SampleTowerDefence.Scripts.Controller.Pool;
using SampleTowerDefence.Scripts.Scriptables;
using SampleTowerDefence.Scripts.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction
{
    public class ConstructorBehaviour : MonoBehaviour
    {
        public enum ConstructionMode
        {
            Barrier,
            Tower
        }
        
        [SerializeField] private float cameraDistance = 50f;
        [SerializeField] private LayerMask layerForBarrier;
        [SerializeField] private LayerMask layerForTower;
        [SerializeField] private float placeholderHeigh;
        
        [Header("Objects References")]
        [SerializeField] private Transform placeholderTransform;
        [SerializeField] private GameObject barrierObject;
        [SerializeField] private GameObject towerObject;
        
        [Header("Status Control")]
        [SerializeField] private bool canPlace;
        [SerializeField] private bool enableConstruction;
        [SerializeField] private bool confirmingView;
        [SerializeField] private Model.Construction.ConstructionType structureToCreate;

        [Header("Other References")]
        [SerializeField] private ConstructionScriptableObject barrierData;
        [SerializeField] private ConstructionScriptableObject towerData;
        [SerializeField] private ConfirmDialogView confirmDialogView;
        [SerializeField] private GameView gameView;

        // Update is called once per frame
        private void Update()
        {
            if (enableConstruction && !confirmingView)
                ChoosingConstructionPlace();

            if (enableConstruction && canPlace && Input.GetMouseButtonUp(0) && !confirmingView)
            {
                confirmDialogView.OpenView(placeholderTransform.position);
                gameView.CloseView();
            }
        }

        public void EnableConstruction(ConstructionMode mode)
        {
            gameView.CloseView();
            
            enableConstruction = true;

            switch (mode)
            {
                case ConstructionMode.Barrier:
                    barrierObject.SetActive(true);
                    structureToCreate = Model.Construction.ConstructionType.Barrier;
                    break;
                case ConstructionMode.Tower:
                    towerObject.SetActive(true);
                    structureToCreate = Model.Construction.ConstructionType.Tower;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
            
            Invoke(nameof(EnablePlacement), 0.2f);
        }

        public void DisableConstruction()
        {
            DisablePlacement();
            
            enableConstruction = false;
            
            barrierObject.SetActive(false);
            towerObject.SetActive(false);
        }

        private void ChoosingConstructionPlace()
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast (ray, out hit, cameraDistance, GetLayerMask())) 
            {
                Debug.DrawLine (ray.origin, hit.point);
                placeholderTransform.position = new Vector3(hit.point.x, placeholderHeigh, hit.point.z);
            }
        }

        private LayerMask GetLayerMask()
        {
            switch (structureToCreate)
            {
                case Model.Construction.ConstructionType.Barrier:
                    return layerForBarrier;
                case Model.Construction.ConstructionType.Tower:
                    return layerForTower;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void EnablePlacement()
        {
            canPlace = true;
        }

        private void DisablePlacement()
        {
            canPlace = false;
        }

        public void SetConfirming(bool value)
        {
            confirmingView = value;
        }

        public void PlaceConstruction()
        {
            DisableConstruction();
            var newConstruction = PoolController.Instance.GetAvailableConstruction();

            newConstruction.transform.position = placeholderTransform.position;
            
            newConstruction.SpawnConstruction(GetConstruction());
        }

        private Model.Construction GetConstruction()
        {
            switch (structureToCreate)
            {
                case Model.Construction.ConstructionType.Barrier:
                    return new Model.Construction(barrierData.GetConstructionData());
                case Model.Construction.ConstructionType.Tower:
                    return new Model.Construction(towerData.GetConstructionData());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void CancelPlacementConstruction()
        {
            DisableConstruction();
        }
    }
}
