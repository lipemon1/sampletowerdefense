using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.Enemy;
using SampleTowerDefence.Scripts.Controller.Pool;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class OnTargetEnemyBehaviour : MonoBehaviour
    {
        private bool _canKillPlayer;
        
        private void OnEnable()
        {
            Invoke(nameof(EnableKillPlayer), 1f);
        }

        private void OnDisable()
        {
            _canKillPlayer = false;
        }

        private void EnableKillPlayer()
        {
            _canKillPlayer = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_canKillPlayer) return;
            
            if (other.CompareTag("Target Area"))
            {
                var enemyBehaviour = this.GetComponent<PrepareEnemyBehaviour>();
                enemyBehaviour.DespawnEnemy();
                
                LoopController.Instance.NewEnemyDone(true);
                PoolController.Instance.ReturnEnemyToPool(enemyBehaviour);
            }
        }
    }
}