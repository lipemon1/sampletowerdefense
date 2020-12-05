using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class PrepareEnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private EnemyScriptableObject enemyData;
        [SerializeField] private LifeBehaviour lifeBehaviour;
        [SerializeField] private EnemyMovementBehaviour enemyMovementBehaviour;
        
        private void Awake()
        {
            lifeBehaviour.PrepareBehaviour(enemyData.GetEnemyLife());
            enemyMovementBehaviour.PrepareBehaviour(enemyData.GetEnemySpeed());
            Destroy(this);
        }
    }
}
