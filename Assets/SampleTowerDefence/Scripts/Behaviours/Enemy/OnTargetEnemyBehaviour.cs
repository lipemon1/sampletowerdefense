using SampleTowerDefence.Scripts.Controller.Core;
using SampleTowerDefence.Scripts.Controller.Enemy;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class OnTargetEnemyBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Target Area"))
            {
                var enemyBehaviour = this.GetComponent<PrepareEnemyBehaviour>();
                enemyBehaviour.DespawnEnemy();
                
                LoopController.Instance.NewEnemyDone();
                EnemyPoolController.Instance.SetNewEnemyOnPool(enemyBehaviour);
            }
        }
    }
}