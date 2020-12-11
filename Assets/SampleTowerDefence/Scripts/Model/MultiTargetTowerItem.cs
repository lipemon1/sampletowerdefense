using SampleTowerDefence.Scripts.Behaviours.Construction.Towers;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Model
{
    [System.Serializable]
    public class MultiTargetTowerItem
    {
        [SerializeField] private GameObject enemyObject;
        [SerializeField] private SingleTargetTowerBehaviour towerTargetBehaviour;

        public MultiTargetTowerItem(GameObject enemyObject, SingleTargetTowerBehaviour towerTargetBehaviour)
        {
            this.enemyObject = enemyObject;
            this.towerTargetBehaviour = towerTargetBehaviour;
        }

        public void StartAttacking(float delayToAttack)
        {
            towerTargetBehaviour.StartAttacking(enemyObject, delayToAttack);
        }

        public void StopAttacking()
        {
            towerTargetBehaviour.StopAttacking();
        }

        public bool IsSameObject(GameObject objectToCompare)
        {
            return objectToCompare == enemyObject;
        }
    }
}
