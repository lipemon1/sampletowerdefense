using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Model;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction.Towers
{
    public class MultiTargetTowerBehaviour : MonoBehaviour
    {
        [SerializeField] private List<Model.MultiTargetTowerItem> currentTargets = new List<MultiTargetTowerItem>();
        [SerializeField] private List<SingleTargetTowerBehaviour> targetsBehaviours = new List<SingleTargetTowerBehaviour>();
        [SerializeField] private float delayToAttack;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;

            var availableSingleTarget = GetAvailableSingleTargetTowerBehaviour();

            if (availableSingleTarget == null) return;
            
            var newTargetItem =
                new MultiTargetTowerItem(other.transform.gameObject, availableSingleTarget);
            
            newTargetItem.StartAttacking(delayToAttack);
            
            currentTargets.Add(newTargetItem);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            
            var targetToStop = currentTargets.FirstOrDefault(cr => cr .IsSameObject(other.transform.gameObject));
            
            if (targetToStop != null)
            {
                targetToStop.StopAttacking();
                currentTargets.Remove(targetToStop);
            }
        }

        private SingleTargetTowerBehaviour GetAvailableSingleTargetTowerBehaviour()
        {
            return targetsBehaviours.FirstOrDefault(tb => !tb.IsAttacking());
        }
    }
}
