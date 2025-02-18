using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
       
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);
        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
