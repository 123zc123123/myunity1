using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1HitState : EnemyState
{
    public Enemy1HitState(string _stateName, string _animName, BaseEnemy _enemy) : base(_stateName, _animName, _enemy)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        animOverTrigger = false;
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
            enemy.stateMachine.ChangeState(enemy.idleState);
        }
        
    }
}
