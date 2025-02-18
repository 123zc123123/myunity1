using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.SetVelocity(rb.velocity.x, player.jumpForce);
        player.canJump = false;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (rb.velocity.y <= 0) 
        {
            stateMachine.ChangeState(player.fallState);
        }

    }
}
