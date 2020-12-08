using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Behaviours.Enemy;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Enemy
{
    public class EnemyPoolController : MonoBehaviour
    {
        [SerializeField] private List<PrepareEnemyBehaviour> enemiesAvailable = new List<PrepareEnemyBehaviour>();

        public PrepareEnemyBehaviour GetAvailableEnemy()
        {
            return enemiesAvailable?.Count > 0 ? enemiesAvailable.PopAt(0) : null;
        }

        public void ReturnEnemyToPool(PrepareEnemyBehaviour enemyBehaviour)
        {
            enemiesAvailable.Add(enemyBehaviour);
        }
    }
}