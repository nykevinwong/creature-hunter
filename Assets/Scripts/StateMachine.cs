using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class StateMachine
    {
        public State CurrentState { get; private set; }
        public StateMachine()
        {
        }

        public void ChangeState(State newState)
        {
            if (CurrentState != null) { CurrentState.Exit(); }

            newState.Enter();
            CurrentState = newState;
        }
    }

