﻿using SampleTowerDefence.Scripts.Scriptables;
using UnityEngine;
using UnityEngine.AI;

namespace SampleTowerDefence.Scripts.Behaviours.Enemy
{
    public class EnemyMovementBehaviour : MonoBehaviour
    {
        [HideInInspector] private Vector3 _targetPos;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private bool _canMove;

        public void PrepareBehaviour(float enemySpeed, Vector3 newTargetPos)
        {
            agent.speed = enemySpeed;
            this._targetPos = newTargetPos;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
                StartMovement();
            
            if(Input.GetKeyDown(KeyCode.T))
                StopMovement();
        }

        public void StartMovement()
        {
            _canMove = true;
            agent.isStopped = !_canMove;
            agent.SetDestination(_targetPos);
        }

        public void StopMovement()
        {
            _canMove = false;
            agent.isStopped = !_canMove;
        }
    }
}