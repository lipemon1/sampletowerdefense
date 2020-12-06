using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;
using UnityEngine.AI;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class EnemyMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform targetPos;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private bool canMove;

        public void PrepareBehaviour(float enemySpeed)
        {
            speed = enemySpeed;
        }

        private void Update()
        {
            if(canMove)
                MoveToTarget();
        }

        public void StartMovement()
        {
            canMove = true;
        }

        public void StopMovement()
        {
            canMove = false;
        }

        private void MoveToTarget()
        {
            agent.Move(GetDirectionToMove());
        }

        private Vector3 GetDirectionToMove()
        {
            return (targetPos.position - this.transform.position).normalized.normalized * speed * Time.deltaTime;
        }
    }
}