using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction
{
    public class PrepareConstructionBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject barrierObject;
        [SerializeField] private MeshRenderer meshRenderer;

        private void PrepareDependencies(Model.Construction construction)
        {
            meshRenderer.material = construction.material;
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
