using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine
    {
        private OnePunchManController Owner;
        private IState currentState;
        protected Dictionary<OnePunchManStates, IState> States = new Dictionary<OnePunchManStates, IState>();

        public OnePunchManStateMachine(OnePunchManController Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }
        public void Update() => currentState?.Update();
        private void CreateStates()
        {
            States.Add(OnePunchManStates.IDLE, new IdleState(this));
            States.Add(OnePunchManStates.ROTATING, new RotatingState(this));
            States.Add(OnePunchManStates.SHOOTING, new ShootingState(this));
        }
        private void SetOwner()
        {
            foreach(IState state in States.Values)
            {
                state.Owner = Owner;
            }
        }
        protected void ChangeState(IState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState?.OnStateEnter();
        }
        public void ChangeState(OnePunchManStates newState) => ChangeState(States[newState]);
    }
    public enum OnePunchManStates
    {
        IDLE,
        ROTATING,
        SHOOTING
    }
}
