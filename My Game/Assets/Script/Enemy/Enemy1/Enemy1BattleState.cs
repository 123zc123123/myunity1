using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1BattleState : EnemyState
{
    

    public Enemy1BattleState(string _stateName, string _animName, BaseEnemy _enemy) : base(_stateName, _animName, _enemy)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        time = 0;
    }

    public override void ExitState()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Move", true);
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //�����ⲻ��������߼�⵽ǽ������ҳ����˾��䷶Χ������Ҿ��볬���˾��䷶Χ���ͻص�Ѳ��״̬�����Է�Ϊx��y�ֱ��⣬������ɸġ�
        if (!enemy.DeteGround() || (enemy.DeteWall() && Vector2.Distance(enemy.transform.position, player.transform.position) > enemy.warnDistance)|| Vector2.Distance(enemy.transform.position, player.transform.position) > enemy.warnDistance) 
        {
            
            anim.SetBool("Idle", true);
            anim.SetBool("Move", false);
            stateMachine.ChangeState(enemy.idleState);
        }
        //��ҽ��빥����Χ���ͽ��빥��״̬,���˿��Թ����͹�����������о�վ��
        if (Vector2.Distance(enemy.transform.position, player.transform.position) <= enemy.attackDeteRadius&&enemy.canAttack) 
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Move", true);
            
            stateMachine.ChangeState(enemy.attackState);
        }
        else if (Vector2.Distance(enemy.transform.position, player.transform.position) <= enemy.attackDeteRadius && !enemy.canAttack) 
        {
            anim.SetBool("Move", false);
            anim.SetBool("Idle", true);
            enemy.SetZeroVelocity();
        }
        //��ҳ���������Χ��
        if (time>0.2f&& Vector2.Distance(enemy.transform.position, player.transform.position) > enemy.attackDeteRadius && Vector2.Distance(enemy.transform.position, player.transform.position) < enemy.warnDistance)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Move", true);

            if (player.transform.position.x - enemy.transform.position.x >= 0)
                enemy.SetVelocity(enemy.moveSpeed, rb.velocity.y);
            else
                enemy.SetVelocity(-enemy.moveSpeed, rb.velocity.y);

        }
    }
}
