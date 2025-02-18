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
        //如果检测不到地面或者检测到墙并且玩家超出了警戒范围或者玩家距离超过了警戒范围，就回到巡逻状态。可以分为x和y分别检测，看需求可改。
        if (!enemy.DeteGround() || (enemy.DeteWall() && Vector2.Distance(enemy.transform.position, player.transform.position) > enemy.warnDistance)|| Vector2.Distance(enemy.transform.position, player.transform.position) > enemy.warnDistance) 
        {
            
            anim.SetBool("Idle", true);
            anim.SetBool("Move", false);
            stateMachine.ChangeState(enemy.idleState);
        }
        //玩家进入攻击范围，就进入攻击状态,敌人可以攻击就攻击，如果不行就站着
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
        //玩家超出攻击范围。
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
