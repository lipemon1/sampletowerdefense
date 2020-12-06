using System.Collections.Generic;
using System.Linq;
using SampleTowerDefence.Scripts.Behaviours.Enemy;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Enemy
{
    public class EnemyPoolController : MonoBehaviour
    {
        public static EnemyPoolController Instance { get; set; }
        
        [SerializeField] private List<PrepareEnemyBehaviour> enemiesAvailable = new List<PrepareEnemyBehaviour>();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public PrepareEnemyBehaviour GetAvailableEnemy()
        {
            return enemiesAvailable?.Count > 0 ? enemiesAvailable.PopAt(0) : null;
        }

        public void SetNewEnemyOnPool(PrepareEnemyBehaviour enemyBehaviour)
        {
            enemiesAvailable.Add(enemyBehaviour);
        }
    }
}