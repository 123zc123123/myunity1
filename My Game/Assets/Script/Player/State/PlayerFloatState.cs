using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloatState : PlayerState
{
    private float gravity;
    public PlayerFloatState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
        gravity = player.rb.gravityScale;
    }

    public override void EnterState()
    {
        base.EnterState();
        player.rb.gravityScale = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.rb.gravityScale = gravity;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelocity(xInput * player.moveSpeed , yInput*2.5f);
        if (player.DeteGround()) 
        {
            stateMachine.ChangeState(player.idleState);
        }
        if (player.DeteWall()) 
        {
            stateMachine.ChangeState(player.wallClimbState);
        }
    }
}
