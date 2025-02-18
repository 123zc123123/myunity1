using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//往上方击退自身
public class MaxWindSkill : PlayerSkill
{
    public MaxWindPrefab maxWindPrefab;

    public MaxWindSkill(Player _player, SkillType _skillType, PlayerSkillManager _skillManager, PlayerSkillGroup _skillGroup = null) : base(_player, _skillType, _skillManager, _skillGroup)
    {
        animTrigger = "Wind";

    }

    public override void SkillTrigger()
    {
        base.SkillTrigger();
        if (maxWindPrefab != null)
        {
            player.stateMachine.ChangeState(player.idleState);
            player.canAttack = true;
            return;
        }
        player.anim.SetBool("Wind", true);
        player.canDash = false;

        isUseSkill = true;
    }

    public void CreateWind()
    {
        clonePrefabIndex = 3;
        maxWindPrefab = skillManager.CreatePrefab(clonePrefabIndex,new Vector3(player.transform.position.x, player.transform.position.y-1.47f), Quaternion.identity).GetComponent<MaxWindPrefab>();
        player.SetVelocity(player.rb.velocity.x, 8);
    }

    public override void SkillUpdate()
    {
        base.SkillUpdate();
        //动画播放完毕后再转换状态。可以考虑让其能再跳一次。
        if (player.stateMachine.currentState.animOverTrigger)
        {
            player.anim.SetBool("Wind", false);
            player.canAttack = true;
            player.canDash = true;
            player.stateMachine.ChangeState(player.fallState);
        }
        if (time > 1f)
        {
            maxWindPrefab.Dead();
            isUseSkill = false;
            maxWindPrefab = null;
            time = 0;
        }
    }

    
}
