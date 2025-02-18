using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
        player.canJump = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
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
