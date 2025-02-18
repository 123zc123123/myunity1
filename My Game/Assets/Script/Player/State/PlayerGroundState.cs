using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        //进入地面状态后，就可以跳跃
        player.canJump = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Input.GetKeyDown(KeyCode.Mouse0) && player.canAttack)
        {
            if (player.attackTime > 3)
                player.attackCount = 0;
            player. attackTime = 0;
            player.canAttack = false;
            stateMachine.ChangeState(player.attackState);

        }
        
        //Input.GetKeyDown(dataBase.keyControllerPair["Jump"])方便测试先用指定的代替，回头可修改
        //跳跃要满足三个条件，输入，可以跳，没在播出动画
        if (Input.GetKeyDown(KeyCode.Space) && player. canJump&&animOverTrigger)
        {
            stateMachine.ChangeState(player.jumpState);
        }
        //从高处地面往下走。
        if (player.canJump && !player.DeteGround())
        {
            stateMachine.ChangeState(player.fallState);
        }
        if (player.canDefense && Input.GetKeyDown(KeyCode.N)) 
        {
            stateMachine.ChangeState(player.defenseState);
        }

      
    }
}
