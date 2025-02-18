using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AttackState :EnemyState
{
    public Enemy1AttackState(string _stateName, string _animName, BaseEnemy _enemy) : base(_stateName, _animName, _enemy)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        animOverTrigger = false;
        enemy.SetZeroVelocity();
        enemy.canAttack = false;
        enemy.attackTime = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (animOverTrigger) 
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
