using StatePattern.StateMachine;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrollingState : IState
    {
        public EnemyController Owner { get; set; }
        private IStateMachine stateMachine;

        private int currentPatrollingIndex = -1;
        private Vector3 desination;
        public PatrollingState(IStateMachine stateMachine) 
        {
            this.stateMachine = stateMachine; 
        }
        public void OnStateEnter() 
        { 
            SetNextWayponitIndex();
            desination = GetDestination();
            MoveTowardsDestination();
        }
        public void Update() 
        {
            if (ReachedDestination())
                stateMachine.ChangeState(StateMachine.States.IDLE);
        }
        public void OnStateExit() { }

        private void SetNextWayponitIndex()
        {
            if (currentPatrollingIndex == Owner.Data.PatrollingPoints.Count - 1)
                currentPatrollingIndex = 0;
            else
                currentPatrollingIndex++;
        }
        private Vector3 GetDestination()
        {
            return Owner.Data.PatrollingPoints[currentPatrollingIndex];
        }
        private void MoveTowardsDestination()
        {
            Owner.Agent.isStopped = false;
            Owner.Agent.SetDestination(desination);
        }
        private bool ReachedDestination() => Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance;
    }
}
