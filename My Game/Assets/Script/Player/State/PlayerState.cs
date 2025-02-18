using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected string stateName;

    public string animName { get; protected set; }

    protected Rigidbody2D rb;

    protected float xInput;

    protected float yInput;

    protected float time;

    protected Animator anim;

    protected Player player;

    protected PlayerStateMachine stateMachine;
    //用于需要完整播放动画的状态内，进入时设置为false，播放完设置为true。
    public bool animOverTrigger = true;
    public PlayerState(string _stateName,string _animName,Player _player) 
    {
        stateName = _stateName;
        animName = _animName;
        player = _player;
        rb = player.rb;
        anim = player.anim;
        stateMachine = player.stateMachine;
    }
    //进入此状态时候调用
    public virtual void EnterState() 
    {
        anim.SetBool(animName, true);
    }
    //在此状态中调用
    public virtual void UpdateState() 
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        time += Time.deltaTime;
    }
    //退出此状态时调用
    public virtual void ExitState() 
    {
        anim.SetBool(animName, false);
    }

    public virtual void SetTrigger() 
    {
        animOverTrigger = true;
    }
}
