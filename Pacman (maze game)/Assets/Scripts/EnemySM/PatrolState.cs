using enemy;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.UIElements;
namespace Enemy
{
    public class PatrolState : State
    {
        

        // constructor
        public PatrolState(EnemyScript enemy, StateMachine sm) : base(enemy, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("num points=" + enemy.points.Length);
            Debug.Log("nav=" + enemy.nav);
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
            enemy.CheckForChase();
            Debug.Log("checking for Chase");
            base.LogicUpdate();

            FixedUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }



        public void FixedUpdate()
        {
            if (!enemy.nav.pathPending && enemy.nav.remainingDistance < 0.5f)
            {
                GoToNextPoint();
            }
        }

        void GoToNextPoint()
        {
            if (enemy.points.Length == 0)
            {
                return;
            }

            enemy.nav.destination = enemy.points[enemy.destPoint].position;
            enemy.destPoint = (enemy.destPoint + 1) % enemy.points.Length;
        }
    }
}
