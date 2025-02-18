using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySkillState : PlayerState
{
    //只是用于状态切换，保证状态之间逻辑正常
    public PlaySkillState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        animOverTrigger = false;
    }

    public override void ExitState()
    {
        animOverTrigger = true;
    }

    public override void UpdateState()
    {
        
    }

   
}
