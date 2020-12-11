using System;
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
        [SerializeField] private Model.Construction construction;

        private void Awake()
        {
            targetsBehaviours = GetComponents<SingleTargetTowerBehaviour>().ToList();
        }

        public void SetConstruction(Model.Construction constructionType)
        {
            construction = constructionType;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            
            var availableSingleTarget = GetAvailableSingleTargetTowerBehaviour();

            if (availableSingleTarget == null) return;
            
            var newTargetItem =
                new MultiTargetTowerItem(other.transform.gameObject, availableSingleTarget);
            
            newTargetItem.StartAttacking(delayToAttack, construction.attackValue);
            
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
            switch (construction.structure)
            {
                case Model.Construction.ConstructionType.Barrier:
                    return null;
                case Model.Construction.ConstructionType.MultiTargetTower:
                    if (currentTargets.Count < 3) return targetsBehaviours.FirstOrDefault(tb => !tb.IsAttacking());
                    return null;
                case Model.Construction.ConstructionType.AreaDamageTower:
                    return targetsBehaviours.FirstOrDefault(tb => !tb.IsAttacking());
                case Model.Construction.ConstructionType.SlowTargetTower:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
