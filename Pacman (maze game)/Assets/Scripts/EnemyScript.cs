using enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyScript : MonoBehaviour
    {

        public Transform[] points;
        public NavMeshAgent nav;
        public int destPoint;
        public GameObject Player;
        public GameObject Spawn;
        public PatrolState patrolState;
        public ChaseState chaseState;
        public StateMachine sm;
        public bool playerDetected;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            sm = gameObject.AddComponent<StateMachine>();

            patrolState = new PatrolState(this, sm);
            chaseState = new ChaseState(this, sm);

            sm.Init(patrolState);
        }

        // Update is called once per frame
        void Update()
        {
            sm.CurrentState.LogicUpdate();
        }

        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        public void CheckForPatrol()
        {
            if (playerDetected == false) // key held down
            {
                sm.ChangeState(patrolState);
                return;
            }
        }
        public void CheckForChase()
        {
            if (playerDetected == true) // key held down
            {
                sm.ChangeState(chaseState);
                return;

            }
        }
    }
}