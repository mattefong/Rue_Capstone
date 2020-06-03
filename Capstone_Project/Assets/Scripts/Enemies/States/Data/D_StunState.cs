using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStunSateData", menuName = "Data/Entity Data/Stun Data")]

public class D_StunState : ScriptableObject
{
    public float stunTime = 1f;

    public float stunKnocbackTime = 0.2f;
    public float stunKnockbackSpeed = 20f;
    public Vector2 stunKnockbackAngle;
}
