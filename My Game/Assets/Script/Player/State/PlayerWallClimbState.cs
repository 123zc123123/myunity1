using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerState
{
    public PlayerWallClimbState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.canJump = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //��Ϊ0��Ȼ�����Ϊ�����������»���
        player.SetZeroVelocity();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }
        //�ڿ���״̬
        if (!player.DeteWall() &&!player.DeteGround()) 
        {
            stateMachine.ChangeState(player.fallState);
        }
        if (player.DeteGround())
        {
            stateMachine.ChangeState(player.idleState);
        }
        
    }
}
