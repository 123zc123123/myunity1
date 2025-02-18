using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSwitchPosition : PlayerSkill
{
    public CloneSwitchPosition( Player _player, SkillType _skillType, PlayerSkillManager _skillManager, PlayerSkillGroup _skillGroup=null) : base( _player, _skillType, _skillManager, _skillGroup)
    {
        animTrigger = "";
    }

    public override void SkillTrigger()
    {
        base.SkillTrigger();
        if (player.cloneSkill.clone == null)
        {
            player.cloneSkill.SkillTrigger();
            return; 
        }
        if (player.transform.rotation != player.cloneSkill.clone.transform.rotation) 
        {
            player.faceDir *= -1;
            player.faceRight = !player.faceRight;
            player.cloneSkill.clone.faceDir *= -1;
            player.cloneSkill.clone.faceRight = !player.cloneSkill.clone.faceRight;

        }
        Vector3 playerPosition = player.transform.position;
        Quaternion playerRotation = player.transform.rotation;
        player.transform.position = player.cloneSkill.clone.transform.position;
        player.transform.rotation = player.cloneSkill.clone.transform.rotation;

        player.cloneSkill.clone.transform.position = playerPosition;
        player.cloneSkill.clone.transform.rotation = playerRotation;

        player.stateMachine.ChangeState(player.idleState);
    }

    public override void SkillUpdate()
    {
        base.SkillUpdate();
    }
}
