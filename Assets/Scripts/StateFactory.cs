using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class StateFactory
{

    public enum EnumBirdStates
    {
        BirdFly,
        BirdDamaged,
    }
    public static State CreateState(Entity player, EnumBirdStates state)
    {
        StateMachine stateMachine = player.StateMachine;

        switch (state)
        {
            case EnumBirdStates.BirdFly:
                return new BirdFlyState(stateMachine, player, state.ToString());
        }

        return null;
    }
}

