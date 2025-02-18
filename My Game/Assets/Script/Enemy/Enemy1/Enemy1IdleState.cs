using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1IdleState : EnemyState
{
    public Enemy1IdleState(string _stateName, string _animName, BaseEnemy _enemy) : base(_stateName, _animName, _enemy)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.SetZeroVelocity();
        time = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
       
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (time >= 2) 
        {
            enemy.stateMachine.ChangeState(enemy.moveState);
            enemy.SetVelocity(-enemy.faceDir, 0);
        }
        if (Vector2.Distance(player.transform.position, enemy.transform.position) < enemy.warnDistance&&enemy.DeteGround())
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
