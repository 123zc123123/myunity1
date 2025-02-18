using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState :PlayerState
{
    private float gravity;
    //用于记录当前是否能跳
    private bool canJump;
    public PlayerHurtState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
        gravity = player.rb.gravityScale;
    }

    public override void EnterState()
    {
        base.EnterState();
        player.SetZeroVelocity();
        player.canHurt = false;
        animOverTrigger = false;
        player.canAttack = false;
        player.canDash = false;
        player.canDefense = false;
        canJump = player.canJump;
        player.canJump = false;
        player.rb.gravityScale = 0;
        if(player.faceRight)
            player.rb.velocity = new Vector3(-3, 0);
        else
            player.rb.velocity = new Vector3(3, 0);
    }
    //受伤状态结束后才能
    public override void ExitState()
    {
        base.ExitState();
        player.rb.gravityScale = gravity;
        player.canAttack = true;
        player.canDefense = true;
        player.canJump = canJump;
        player.canDash = true;
        player.hurtTime = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (animOverTrigger) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
