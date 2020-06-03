using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AnimationToStateMachine : MonoBehaviour
{
    public SC_AttackState attackState;

    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
