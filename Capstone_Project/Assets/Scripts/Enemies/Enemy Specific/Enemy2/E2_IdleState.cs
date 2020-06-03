﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_IdleState : SC_IdleState
{
    private SC_Enemy2 enemy;

    public E2_IdleState(SC_Entity entity, SC_FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, SC_Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        //TODO: pds

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}