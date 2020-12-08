using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;
using UnityEngine.AI;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class EnemyMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform targetPos;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private bool canMove;

        public void PrepareBehaviour(float enemySpeed)
        {
            agent.speed = enemySpeed;
        }

        private void Update()
        {
            if(canMove)
                agent.SetDestination(targetPos.position);
        }

        public void StartMovement()
        {
            canMove = true;
            agent.isStopped = !canMove;
        }

        public void StopMovement()
        {
            canMove = false;
            agent.isStopped = !canMove;
        }
    }
}