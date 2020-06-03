using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_MoveState : SC_MoveState
{
    private SC_Enemy2 enemy;

    public E2_MoveState(SC_Entity entity, SC_FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, SC_Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        //TODO: Transition to playerDetectedState

        if(isDetectingWall || isDetectingLedge)
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
