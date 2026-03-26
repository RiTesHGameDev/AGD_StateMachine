using StatePattern.StateMachine;
namespace StatePattern.Enemy
{
    public class ChasingState : IState
    {
        public EnemyController Owner { get; set; }
        private OnePunchManStateMachine stateMachine;

        public ChasingState(OnePunchManStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        public void OnStateEnter() { }
        public void Update() { }
        public void OnStateExit() { }
    }
}
