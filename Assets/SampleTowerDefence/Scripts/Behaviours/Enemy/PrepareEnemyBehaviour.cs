using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class PrepareEnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject enemyObject;
        [HideInInspector] private LifeBehaviour _lifeBehaviour;
        [HideInInspector] private EnemyMovementBehaviour _enemyMovementBehaviour;
        [SerializeField] private MeshRenderer meshRenderer;

        private void PrepareDependencies(Model.Enemy enemy, Vector3 targetPos)
        {
            if(_lifeBehaviour == null)
                _lifeBehaviour = enemyObject.GetComponent<LifeBehaviour>();
            
            if(_enemyMovementBehaviour == null)
                _enemyMovementBehaviour = enemyObject.GetComponent<EnemyMovementBehaviour>();
            
            _lifeBehaviour.PrepareBehaviour(enemy.life);
            _enemyMovementBehaviour.PrepareBehaviour(enemy.speed, targetPos);
            meshRenderer.material = enemy.material;
        }

        public void SpawnEnemy(Model.Enemy enemy, Vector3 targetPos)
        {
            PrepareDependencies(enemy, targetPos);
            
            _lifeBehaviour.ResetLife();
            
            enemyObject.SetActive(true);
            
            _enemyMovementBehaviour.StartMovement();
        }

        public void DespawnEnemy()
        {
            _enemyMovementBehaviour.StopMovement();
            enemyObject.SetActive(false);
        }
    }
}