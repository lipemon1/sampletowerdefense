using SampleTowerDefence.Scripts.Behaviours.Construction;
using SampleTowerDefence.Scripts.Behaviours.Enemy;
using SampleTowerDefence.Scripts.Controller.Construction;
using SampleTowerDefence.Scripts.Controller.Enemy;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Controller.Pool
{
    public class PoolController : MonoBehaviour
    {
        public static PoolController Instance { get; set; }

        [SerializeField] private EnemyPoolController enemyPoolController;
        [SerializeField] private ConstructionPoolController constructionPoolController;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        #region Enemy

        public PrepareEnemyBehaviour GetAvailableEnemy()
        {
            return enemyPoolController.GetAvailableEnemy();
        }

        public void ReturnEnemyToPool(PrepareEnemyBehaviour enemy)
        {
            enemyPoolController.ReturnEnemyToPool(enemy);
        }

        public void ReturnAllEnemies()
        {
            var allEnemies = FindObjectsOfType<PrepareEnemyBehaviour>();

            foreach (var prepareEnemyBehaviour in allEnemies)
            {
//                var movement = prepareEnemyBehaviour.GetComponent<EnemyMovementBehaviour>();
//                movement.StopMovement();
                
                prepareEnemyBehaviour.DespawnEnemy();
                ReturnEnemyToPool(prepareEnemyBehaviour);
            }
        }

        #endregion

        #region Construction

        public PrepareConstructionBehaviour GetAvailableConstruction()
        {
            return constructionPoolController.GetAvailableConstruction();
        }

        public void ReturnConstructionToPool(PrepareConstructionBehaviour construction)
        {
            construction.DespawnConstruction();
            constructionPoolController.ReturnConstructionToPool(construction);
        }

        #endregion
    }
}
