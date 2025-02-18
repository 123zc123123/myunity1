using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        
    }
    //空中状态退出不一定是到地面，也有其他情况。
    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelocity(xInput * player.moveSpeed * 0.8f, rb.velocity.y);
        
        
    }
}
