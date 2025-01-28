using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class StateFactory
{

    public enum EnumBirdStates
    {
        BirdFly,
        BirdDeath,
        BirdInit,
        BirdDamaged
    }
    public static State CreateState(Entity player, EnumBirdStates state)
    {
        StateMachine stateMachine = player.StateMachine;

        switch (state)
        {
            case EnumBirdStates.BirdInit:
                return new BirdInitState(stateMachine, player, EnumBirdStates.BirdFly.ToString());
            case EnumBirdStates.BirdFly:
                return new BirdFlyState(stateMachine, player, state.ToString());
            case EnumBirdStates.BirdDamaged:
                return new BirdDamagedState(stateMachine, player, state.ToString());
            case EnumBirdStates.BirdDeath:
                return new BirdDeathState(stateMachine, player, state.ToString());
        }

        return null;
    }
}

