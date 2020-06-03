using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeadState : SC_DeadState
{
    private SC_Enemy1 enemy;
    public E1_DeadState(SC_Entity entity, SC_FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, SC_Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
