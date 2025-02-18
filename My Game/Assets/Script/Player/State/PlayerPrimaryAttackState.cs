using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerGroundState
{
    private string attackCountName;
    public PlayerPrimaryAttackState(string _stateName, string _animName, Player _player,string _attackCountName) : base(_stateName, _animName, _player)
    {
        attackCountName = _attackCountName;
    }

    public override void EnterState()
    {
        base.EnterState();
        
        animOverTrigger = false;
        anim.SetInteger(attackCountName, player.attackCount);
        
    }

    public override void ExitState()
    {
        base.ExitState();
        player.attackCount += 1;
        if (player.attackCount % 3 == 0)
            player.attackCount = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (time > 0) 
        {
            player.SetZeroVelocity();
        }
        //ĳ�ι��������󣬲��ܹ���
        if (animOverTrigger) 
        {
            player.canAttack = true;
            stateMachine.ChangeState(player.idleState);
        }
        //��ϼ��ܽ�������ܹ���
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            stateMachine.ChangeState(player.defenseState);
        }
    }
}
