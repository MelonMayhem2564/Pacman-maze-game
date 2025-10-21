using enemy;
using UnityEngine;
namespace Enemy
{
    public class ChaseState : State
    {
        // constructor
        public ChaseState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            enemy.CheckForPatrol();
            Debug.Log("checking for Patrol");
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
