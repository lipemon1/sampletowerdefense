using UnityEngine;

namespace SampleTowerDefence.Scripts.Model
{
    [System.Serializable]
    public class Construction
    {
        public enum ConstructionType
        {
            Barrier,
            Tower
        }
        
        public Material material;
        public ConstructionType structure;

        public Construction(Material material, ConstructionType structure)
        {
            this.material = material;
            this.structure = structure;
        }
        
        public Construction(Construction construction)
        {
            this.material = construction.material;
            this.structure = construction.structure;
        }
    }
}
