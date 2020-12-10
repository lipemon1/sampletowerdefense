using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.Enemy;
using SampleTowerDefence.Scripts.Controller.Pool;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Enemy
{
    public class EnemyPoolController : ObjectPoolController<PrepareEnemyBehaviour>
    {
        public PrepareEnemyBehaviour GetAvailableEnemy()
        {
            return GetAvailableObject();
        }

        public void ReturnEnemyToPool(PrepareEnemyBehaviour enemyBehaviour)
        {
            ReturnObjectToPool(enemyBehaviour);
        }
    }
}