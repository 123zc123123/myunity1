using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenseState : PlayerState
{
    public PlayerDefenseState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        time = 0;
        player.canDefense = false;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.canAttack = true;
        animOverTrigger = true;
        player.canDefense = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (time > 0.1f)
        {
            if (player.DeteGround())
                stateMachine.ChangeState(player.idleState);
            else
                stateMachine.ChangeState(player.fallState);
        }
        else
        {
            rb.velocity = new Vector2(-player.faceDir, 0);
        }
    }
}
    

