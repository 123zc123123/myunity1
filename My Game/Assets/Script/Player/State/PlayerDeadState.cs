using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        animOverTrigger = false;
    }

    public override void ExitState()
    {
        player.canAttack = true;
        player.canDefense = true;
        player.canJump = true;
        player.canDash = true;
        player.hurtTime = 0;
        player.isDead = false;
        base.ExitState();
       
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //播放完动画后在合适地方复活
        if (animOverTrigger) 
        {
            player.ReviveOnLoder();
        }
    }

}
