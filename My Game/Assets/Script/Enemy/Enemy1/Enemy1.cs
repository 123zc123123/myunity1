using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 :BaseEnemy
{
    protected override void Start()
    {
        base.Start();
        enemyAtrribute = GetComponent<Enemy1Attribute>();
        SetStartState();
        stateMachine.SetStartState(idleState);
        canAttack = true;
        attackTime = 0;
    }

    private void SetStartState()
    {
        attackState = new Enemy1AttackState("attack", "Attack", this);
        idleState = new Enemy1IdleState("idle", "Idle", this);
        deadState = new Enemy1DeadState("dead", "Dead", this);
        moveState = new Enemy1MoveState("move", "Move", this);
        battleState = new Enemy1BattleState("battle", "Move", this);
        hitState = new Enemy1HitState("hit", "Hit", this);
    }

    

    protected override void Update()
    {
        base.Update();
        attackTime += Time.deltaTime;
        if (attackTime >= 5f&&canAttack==false) 
        {
            canAttack = true;
        }
        FallDie();
    }

    public override void SetDeadState()
    {
        base.SetDeadState();
        stateMachine.ChangeState(deadState);
    }
}
