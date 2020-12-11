using UnityEngine;

namespace SampleTowerDefence.Scripts.Model
{
    [System.Serializable]
    public class Construction
    {
        public enum ConstructionType
        {
            Barrier,
            MultiTargetTower,
            AreaDamageTower,
            SlowTargetTower
        }
        
        public Material material;
        public ConstructionType structure;
        public int attackValue;
        
        public Construction(Construction construction)
        {
            material = construction.material;
            structure = construction.structure;
            attackValue = construction.attackValue;
        }
    }
}
