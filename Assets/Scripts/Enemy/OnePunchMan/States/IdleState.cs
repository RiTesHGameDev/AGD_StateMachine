using System;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class IdleState : IState
    {
        private OnePunchManStateMachine onePunchManStateMachine;
        public OnePunchManController Owner { get; set; }
        private float timer;

        public IdleState(OnePunchManStateMachine onePunchManStateMachine)
        {
            this.onePunchManStateMachine = onePunchManStateMachine;
        }
        public void OnStateEnter() => ResetTimer();
        public void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                onePunchManStateMachine.ChangeState(OnePunchManStates.ROTATING);
            }
        }
        public void OnStateExit() => timer = 0;
        private void ResetTimer() => timer = Owner.Data.IdleTime;
    }
}
