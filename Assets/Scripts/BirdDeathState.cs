using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static StateFactory;

internal class BirdDeathState : State
{

    public BirdDeathState(StateMachine playerStateMachine, Entity entity, string animBoolName) : base(playerStateMachine, entity, animBoolName)
    {
    }

    public override void Enter()
    {
        entity.SetVelocity(0, -2.5f);
        this.entity.PlaySound("falling");
        base.Enter();
    }
    public override void Update()
    {
        base.Update();


        if (entity.transform.position.y < -5.0f)
        {

            this.entity.Destruct();
        }
            


    }
}