using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDictionState : PlayerState
{
    public PlayerDictionState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        player.SetZeroVelocity();
        player.canDash = true;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.canDash = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
