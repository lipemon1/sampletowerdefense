using System;
using System.Collections;
using SampleTowerDefence.Scripts.Behaviours.Enemy;
using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.Pool;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Construction.Towers
{
    public class SingleTargetTowerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject enemyObject;
        [HideInInspector] private LifeBehaviour _enemyLife;
        [HideInInspector] private PrepareEnemyBehaviour _enemyBehaviour;
        [HideInInspector] private EnemyMovementBehaviour _enemyMovementBehaviour;
        [HideInInspector] private bool _attacking;
        [HideInInspector] private Model.Construction _construction;
        
        public void StartAttacking(GameObject newTarget, float delayToAttack, Model.Construction construction)
        {
            _attacking = true;

            _construction = construction;
            
            enemyObject = newTarget;
            _enemyLife = enemyObject.GetComponent<LifeBehaviour>();
            _enemyMovementBehaviour = enemyObject.GetComponent<EnemyMovementBehaviour>();
            _enemyBehaviour = enemyObject.GetComponent<PrepareEnemyBehaviour>();

            switch (construction.structure)
            {
                case Model.Construction.ConstructionType.Barrier:
                    break;
                case Model.Construction.ConstructionType.MultiTargetTower:
                case Model.Construction.ConstructionType.AreaDamageTower:
                    InvokeRepeating(nameof(AttackEnemy), 0f, delayToAttack);
                    break;
                case Model.Construction.ConstructionType.SlowTargetTower:
                    SlowEnemy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AttackEnemy()
        {
            _enemyLife.ApplyDamage(_construction.attackValue, () =>
            {
                _enemyBehaviour.DespawnEnemy();
                
                LoopController.Instance.NewEnemyDone();
                PoolController.Instance.ReturnEnemyToPool(_enemyBehaviour);
                
                StopAttacking();
            });
        }

        private void SlowEnemy()
        {
            _enemyMovementBehaviour.Slow(_construction.attackValue);
        }

        public void StopAttacking()
        {
            if(_construction.structure == Model.Construction.ConstructionType.SlowTargetTower)
                _enemyMovementBehaviour.SpeedUp(_construction.attackValue);
            
            enemyObject = null;
            _enemyLife = null;
            _enemyBehaviour = null;
            
            CancelInvoke(nameof(AttackEnemy));
            _attacking = false;
        }

        public bool IsAttacking()
        {
            return _attacking;
        }
    }
}
