using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected string stateName;

    public string animName { get; protected set; }

    protected Rigidbody2D rb;

    protected float time;

    protected Animator anim;

    protected BaseEnemy enemy;

    protected EnemyStateMachine stateMachine;

    protected Player player;
    //用于需要完整播放动画的状态内，进入时设置为false，播放完设置为true。
    protected bool animOverTrigger = true;
    public EnemyState(string _stateName, string _animName, BaseEnemy _enemy)
    {
        stateName = _stateName;
        animName = _animName;
        enemy = _enemy;
        rb = enemy.rb;
        anim = enemy.anim;
        stateMachine = enemy.stateMachine;
        player = PlayerManeger.instance.player;
    }
    //进入此状态时候调用
    public virtual void EnterState()
    {
        anim.SetBool(animName, true);
    }
    //在此状态中调用
    public virtual void UpdateState()
    {
        time += Time.deltaTime;
    }
    //退出此状态时调用
    public virtual void ExitState()
    {
        anim.SetBool(animName, false);
    }

    //此处trigger的作用是保证当前状态能够顺利播放完毕，并非与其他状态互用自锁。
    public virtual void SetTrigger()
    {
        animOverTrigger = true;
    }
}
