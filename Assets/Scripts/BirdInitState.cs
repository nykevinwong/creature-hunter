using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static StateFactory;

public class BirdInitState : State
{
    public BirdInitState(StateMachine stateMachine, Entity entity, string animBoolName) : base(stateMachine, entity, animBoolName)
    {
    }

    public override void Enter()
    {
        entity.transform.position = new Vector3(Random.Range(-7.5f, 7.5f),
            Random.Range(-3.75f, -2.5f), 0);
        entity.moveSpeed = Random.Range(4f, 10f);
        entity.currentHP = entity.maxHP;
    }

    public override void Update()
    {

        base.Update();
        StateMachine.ChangeState(this.entity.states[EnumBirdStates.BirdFly]);
    }
}

