using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1DeadState : EnemyState
{
    public Enemy1DeadState(string _stateName, string _animName, BaseEnemy _enemy) : base(_stateName, _animName, _enemy)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        animOverTrigger = false;
        enemy.SetZeroVelocity();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(animOverTrigger)
            enemy.DestroyObject();
    }
}
