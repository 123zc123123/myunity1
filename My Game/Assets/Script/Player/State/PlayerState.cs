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
    //������Ҫ�������Ŷ�����״̬�ڣ�����ʱ����Ϊfalse������������Ϊtrue��
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
    //�����״̬ʱ�����
    public virtual void EnterState() 
    {
        anim.SetBool(animName, true);
    }
    //�ڴ�״̬�е���
    public virtual void UpdateState() 
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        time += Time.deltaTime;
    }
    //�˳���״̬ʱ����
    public virtual void ExitState() 
    {
        anim.SetBool(animName, false);
    }

    public virtual void SetTrigger() 
    {
        animOverTrigger = true;
    }
}
