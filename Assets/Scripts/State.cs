using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected StateMachine StateMachine { get; private set; }
    protected Entity entity;
    protected float xInput;
    protected float yInput;
    private string animBoolName;
    protected float stateTimer;

    public State(StateMachine playerStateMachine, Entity entity, string animBoolName)
    {
        StateMachine = playerStateMachine;
        this.entity = entity;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        Debug.Log($"Enter {animBoolName}");
        entity.Anim.SetBool(animBoolName, true);
    }
    public virtual void Exit()
    {
        Debug.Log($"Exit {animBoolName}");
        entity.Anim.SetBool(animBoolName, false);

    }
    public virtual void Update()
    {
        Debug.Log($"Update {animBoolName}");
        stateTimer -= Time.deltaTime;
    }

    public virtual void FixedUpdate()
    {
    }

        



}