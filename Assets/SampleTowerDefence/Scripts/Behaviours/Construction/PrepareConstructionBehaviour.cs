using SampleTowerDefence.Scripts.Behaviours.Construction.Towers;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction
{
    public class PrepareConstructionBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject barrierObject;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private MultiTargetTowerBehaviour multiTargetTowerBehaviour;

        private void PrepareDependencies(Model.Construction construction)
        {
            meshRenderer.material = construction.material;
            multiTargetTowerBehaviour.SetConstruction(construction);
        }

        public void SpawnConstruction(Model.Construction construction)
        {
            PrepareDependencies(construction);
            barrierObject.SetActive(true);
        }

        public void DespawnConstruction()
        {
            barrierObject.SetActive(false);
        }
    }
}
