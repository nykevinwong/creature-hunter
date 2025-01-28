using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static StateFactory;

public class BirdFlyState : State
{
    Vector3 destination;
    float nextSoundDuration = 0;
    float soundElapsedTime = 0;
    public BirdFlyState(StateMachine stateMachine, Entity entity, string animBoolName) : base(stateMachine, entity, animBoolName)
    {
    }

    public override void Enter()
    {
        // if destination is too close to the current position, you will see the duck stuck at current position.

        destination = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-3.75f, 7.5f), 0);
        nextSoundDuration = Random.Range(0.5f, 1.0f);
        entity.moveSpeed = Random.Range(4f, 10f);
        entity.SetVelocity(0f, 0f); // disable velocity when MovePosition method is used.
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

        base.Update();

        entity.transform.position = new Vector3(
        Mathf.Clamp(entity.transform.position.x, -8f, 8f),
        Mathf.Clamp(entity.transform.position.y, -3.75f, 7.5f));

        soundElapsedTime -= Time.deltaTime;

        if (soundElapsedTime <= 0)
        {
            this.entity.PlaySound();
            soundElapsedTime = nextSoundDuration;
        }

        if (entity.transform.position.x < -8 ||
            entity.transform.position.x > 8)
        {
            StateMachine.ChangeState(this.entity.states[EnumBirdStates.BirdFly]);
            return;
        }
        else if (entity.transform.position.y < -3.75f ||
            entity.transform.position.y > 7.5f)
        {
            StateMachine.ChangeState(this.entity.states[EnumBirdStates.BirdFly]);
            return;
        }





    }

    public override void FixedUpdate()
    {
        Vector3 currentPos = entity.transform.position;
        Vector3 towardDir = destination - currentPos;
        towardDir.Normalize();

        entity.Rb.MovePosition(currentPos + (towardDir * Time.deltaTime * entity.moveSpeed));

        // image file is facing right
        this.entity.SR.flipX = (towardDir.x < 0) ? true : false;


        // if the bird reaches the destination, it need a new position instead of stucking at the same position
        if (Vector3.Distance(currentPos, destination) <= 1f) // 1f means it can't be too close.
        {
            StateMachine.ChangeState(this.entity.states[EnumBirdStates.BirdFly]);
            return;
        }
    }

}

