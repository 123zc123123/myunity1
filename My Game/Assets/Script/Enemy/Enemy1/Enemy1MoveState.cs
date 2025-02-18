using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1MoveState : EnemyState
{
    public Enemy1MoveState(string _stateName, string _animName, BaseEnemy _enemy) : base(_stateName, _animName, _enemy)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        time = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //��ҽ��뾯�䷶Χ�ͽ���ս��״̬,��ֹ��һ��վ���ƶ���ս��״̬֮�������л���
        if (time > 0.5f)
        {
            if (Vector2.Distance(player.transform.position, enemy.transform.position) < enemy.warnDistance)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }
        if (!enemy.DeteGround()||enemy.DeteWall())
        {
            stateMachine.ChangeState(enemy.idleState);
        }
        else 
        {
            enemy.SetVelocity(enemy.moveSpeed * enemy.faceDir, 0);
        }
        
    }
}
