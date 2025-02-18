using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : PlayerSkill
{
    
    public ClonePrefab clone;
    public CloneSkill( Player _player, SkillType _skillType, PlayerSkillManager _skillManager, PlayerSkillGroup _skillGroup=null) : base( _player, _skillType, _skillManager, _skillGroup)
    {
        clone = null;
        animTrigger = "";
    }

    public override void SkillTrigger()
    {
        base.SkillTrigger();
        if (clone== null)
        {
            clonePrefabIndex = 0;
            clone = skillManager.CreatePrefab(clonePrefabIndex, player.transform.position,Quaternion.identity).GetComponent<ClonePrefab>();
        }
        else
            player.cloneDir *= -1;
        isUseSkill = true;
        player.canAttack = true;
        player.stateMachine.ChangeState(player.idleState);
    }

    public override void SkillUpdate()
    {
        base.SkillUpdate();

        //测试时先使用小的
        if (time > 15) 
        {
            clone.Dead();
            clone = null;
            isUseSkill = false;
            time = 0;
            return;
        }
        
    }
}
