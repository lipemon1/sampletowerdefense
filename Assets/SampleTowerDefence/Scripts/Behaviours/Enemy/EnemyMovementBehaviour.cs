using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;
using UnityEngine.AI;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class EnemyMovementBehaviour : MonoBehaviour
    {
        [HideInInspector] private Vector3 targetPos;
        [SerializeField] private NavMeshAgent agent;
        [HideInInspector] private bool _canMove;

        public void PrepareBehaviour(float enemySpeed, Vector3 newTargetPos)
        {
            agent.speed = enemySpeed;
            this.targetPos = newTargetPos;
        }

        private void Update()
        {
            if(_canMove)
                agent.SetDestination(targetPos);
        }

        public void StartMovement()
        {
            _canMove = true;
            agent.isStopped = !_canMove;
        }

        public void StopMovement()
        {
            _canMove = false;
            agent.isStopped = !_canMove;
        }
    }
}