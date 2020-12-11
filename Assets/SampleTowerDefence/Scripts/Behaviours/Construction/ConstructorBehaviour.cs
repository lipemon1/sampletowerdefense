using System;
using SampleTowerDefence.Scripts.Controller.Construction;
using SampleTowerDefence.Scripts.Controller.Pool;
using SampleTowerDefence.Scripts.Controller.View;
using SampleTowerDefence.Scripts.Scriptables;
using SampleTowerDefence.Scripts.View;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction
{
    public class ConstructorBehaviour : MonoBehaviour
    {
        [SerializeField] private float cameraDistance = 50f;
        [SerializeField] private LayerMask layerForBarrier;
        [SerializeField] private LayerMask layerForTower;
        [SerializeField] private float placeholderHeigh;
        
        [Header("Objects References")]
        [SerializeField] private Transform placeholderTransform;
        [SerializeField] private GameObject barrierObject;
        [SerializeField] private GameObject multiTargetObject;
        [SerializeField] private GameObject areaTargetObject;
        [SerializeField] private GameObject slowTargetObject;
        
        [Header("Status Control")]
        [SerializeField] private bool canPlace;
        [SerializeField] private bool enableConstruction;
        [SerializeField] private bool confirmingView;
        [SerializeField] private Model.Construction.ConstructionType structureToCreate;

        [Header("Constructions References")]
        [SerializeField] private ConstructionScriptableObject barrierData;
        [SerializeField] private ConstructionScriptableObject multiTargetData;
        [SerializeField] private ConstructionScriptableObject areaTargetData;
        [SerializeField] private ConstructionScriptableObject slowTargetData;

        // Update is called once per frame
        private void Update()
        {
            if (enableConstruction && !confirmingView)
                ChoosingConstructionPlace();
        }

        public void EnableConstruction(Model.Construction.ConstructionType mode)
        {
            ViewController.Instance.CloseView(ViewController.ViewType.GameView);
            
            enableConstruction = true;

            switch (mode)
            {
                case Model.Construction.ConstructionType.Barrier:
                    barrierObject.SetActive(true);
                    structureToCreate = Model.Construction.ConstructionType.Barrier;
                    break;
                case Model.Construction.ConstructionType.MultiTargetTower:
                    multiTargetObject.SetActive(true);
                    structureToCreate = Model.Construction.ConstructionType.MultiTargetTower;
                    break;
                case Model.Construction.ConstructionType.AreaDamageTower:
                    areaTargetObject.SetActive(true);
                    structureToCreate = Model.Construction.ConstructionType.AreaDamageTower;
                    break;
                case Model.Construction.ConstructionType.SlowTargetTower:
                    slowTargetObject.SetActive(true);
                    structureToCreate = Model.Construction.ConstructionType.SlowTargetTower;
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
            multiTargetObject.SetActive(false);
            areaTargetObject.SetActive(false);
            slowTargetObject.SetActive(false);
        }

        private void ChoosingConstructionPlace()
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast (ray, out hit, cameraDistance, GetLayerMask())) 
            {
                Debug.DrawLine (ray.origin, hit.point);
                placeholderTransform.position = new Vector3(hit.point.x, placeholderHeigh, hit.point.z);
                
                if(!placeholderTransform.gameObject.activeInHierarchy)
                    placeholderTransform.gameObject.SetActive(true);
                
                if (enableConstruction && canPlace && Input.GetMouseButtonUp(0) && !confirmingView)
                {
                    SetConfirming(true);
                    ViewController.Instance.OpenView(ViewController.ViewType.ConfirmDialogView, placeholderTransform.position);
                }
            }
            else
            {
                if(placeholderTransform.gameObject.activeInHierarchy)
                    placeholderTransform.gameObject.SetActive(false);
            }
        }

        private LayerMask GetLayerMask()
        {
            switch (structureToCreate)
            {
                case Model.Construction.ConstructionType.Barrier:
                    return layerForBarrier;
                case Model.Construction.ConstructionType.MultiTargetTower:
                case Model.Construction.ConstructionType.AreaDamageTower:
                case Model.Construction.ConstructionType.SlowTargetTower:
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

        public bool IsConfirming()
        {
            return confirmingView;
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
                case Model.Construction.ConstructionType.MultiTargetTower:
                    return new Model.Construction(multiTargetData.GetConstructionData());
                case Model.Construction.ConstructionType.AreaDamageTower:
                    return new Model.Construction(areaTargetData.GetConstructionData());
                case Model.Construction.ConstructionType.SlowTargetTower:
                    return new Model.Construction(slowTargetData.GetConstructionData());
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
