using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType 
{
    AirAndLong,
    AirAndShort,
    GroundAndLong,
    GroundAndShort
}

public class BaseEnemy : Entity
{
    public EnemyType enemyType;

    public EnemyStateMachine stateMachine;

    public EntityAtrribute enemyAtrribute;
    //攻击间隔，避免太快。
    public bool canAttack;
    public float attackTime;

    //状态，如果需要就初始化，不需要可以不初始化。
    public EnemyState attackState;
    public EnemyState moveState;
    public EnemyState deadState;
    public EnemyState idleState;
    public EnemyState battleState;
    public EnemyState hitState;

    public float warnDistance;
    protected override void Start()
    {
        base.Start();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        if (PuaseManager.instance.isPause)
            return;
        if (enemyAtrribute.currentHp.GetValue() <= 0 && stateMachine.currentState != deadState)
        {
            SetDeadState();
        }
        stateMachine.currentState.UpdateState();
    }
    public virtual void DestroyObject()
    {
        Destroy(this.gameObject, 2);
    }

    public override void SetDeadState()
    {
        base.SetDeadState();
        stateMachine.ChangeState(deadState);
    }

    public virtual void DeteTrigger()
    {
        stateMachine.currentState.SetTrigger();
    }
    public virtual void FallDie() 
    {
        if (!DeteGround() && stateMachine.currentState == hitState)
        {
            DestroyObject();
        }
    }
}
