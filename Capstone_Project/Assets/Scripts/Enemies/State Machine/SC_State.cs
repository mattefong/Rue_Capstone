﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_State
{
    protected SC_FiniteStateMachine stateMachine;
    protected SC_Entity entity;

    protected float startTime;

    protected string animBoolName;

    public SC_State(SC_Entity entity, SC_FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    } 

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
    }
    
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }
    
    public virtual void LogicUpdate()
    {

    } 
    
    public virtual void PhysicsUpdate()
    {

    }


}
