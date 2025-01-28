using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static StateFactory;

internal class BirdDamagedState : State
{
    float duration;

    public BirdDamagedState(StateMachine playerStateMachine, Entity entity, string animBoolName) : base(playerStateMachine, entity, animBoolName)
    {
    }

    public override void Enter()
    {
        duration = 0.3f;
        entity.SetVelocity(0, 0);
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        duration -= Time.deltaTime;

        if (duration <= 0)
        {
            StateMachine.ChangeState(this.entity.states[EnumBirdStates.BirdDeath]);
            return;
        }


    }
}