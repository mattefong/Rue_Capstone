﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : SC_MoveState
{
    private SC_Enemy1 enemy;

    public E1_MoveState(SC_Entity entity, SC_FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, SC_Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
