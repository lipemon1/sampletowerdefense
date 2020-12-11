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
        [SerializeField] private bool _attacking;
        [HideInInspector] private int _damage;
        
        public void StartAttacking(GameObject newTarget, float delayToAttack)
        {
            _attacking = true;

            _damage = 25;
            
            enemyObject = newTarget;
            _enemyLife = enemyObject.GetComponent<LifeBehaviour>();
            
            InvokeRepeating(nameof(AttackEnemy), 0f, delayToAttack);
        }

        private void AttackEnemy()
        {
            _enemyLife.ApplyDamage(_damage, () =>
            {
                if (_enemyBehaviour == null)
                    _enemyBehaviour = _enemyLife.GetComponent<PrepareEnemyBehaviour>();
                
                _enemyBehaviour.DespawnEnemy();
                
                LoopController.Instance.NewEnemyDone();
                PoolController.Instance.ReturnEnemyToPool(_enemyBehaviour);
                
                StopAttacking();
            });
        }

        public void StopAttacking()
        {
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
