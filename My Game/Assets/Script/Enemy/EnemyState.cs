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
    //������Ҫ�������Ŷ�����״̬�ڣ�����ʱ����Ϊfalse������������Ϊtrue��
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
    //�����״̬ʱ�����
    public virtual void EnterState()
    {
        anim.SetBool(animName, true);
    }
    //�ڴ�״̬�е���
    public virtual void UpdateState()
    {
        time += Time.deltaTime;
    }
    //�˳���״̬ʱ����
    public virtual void ExitState()
    {
        anim.SetBool(animName, false);
    }

    //�˴�trigger�������Ǳ�֤��ǰ״̬�ܹ�˳��������ϣ�����������״̬����������
    public virtual void SetTrigger()
    {
        animOverTrigger = true;
    }
}
