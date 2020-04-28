using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : SC_IdleState
{
    private SC_Enemy1 enemy;

    public E1_IdleState(SC_Entity entity, SC_FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, SC_Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
