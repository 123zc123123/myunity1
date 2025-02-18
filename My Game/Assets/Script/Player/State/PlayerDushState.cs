using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDushState : PlayerState
{
    public PlayerDushState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        time = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void SetTrigger()
    {
        base.SetTrigger();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (time > 0.2f)
        {
            Vector3 endPosition = player.transform.position;
            player.transform.position = endPosition;
            player.SetZeroVelocity();
            if (player.DeteGround())
                stateMachine.ChangeState(player.idleState);
            else
                stateMachine.ChangeState(player.fallState);
        }
        else 
        {
            rb.velocity = new Vector2(player.dashSpeed*player.faceDir, 0);
        }

        
    }
}
