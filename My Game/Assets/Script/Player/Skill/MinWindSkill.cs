using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于加速自身和减速敌人
public class MinWindSkill : PlayerSkill
{
    public MinWindPrefab minWindPrefab;
    public float gravityScale;
    public MinWindSkill( Player _player, SkillType _skillType, PlayerSkillManager _skillManager, PlayerSkillGroup _skillGroup) : base( _player, _skillType, _skillManager, _skillGroup)
    {
        animTrigger = "Wind";
        gravityScale = player.rb.gravityScale;
    }

    public override void SkillTrigger()
    {
        base.SkillTrigger();
        if (minWindPrefab != null)
        {
            player.canAttack = true;
            player.stateMachine.ChangeState(player.idleState);
            return;
        }
        player.anim.SetBool("Wind", true);
        player.canDash = false;
        player.rb.gravityScale = 0;
        player.SetZeroVelocity();
        isUseSkill = true;
    }

    public void CreateWind()
    {
        clonePrefabIndex = 1;
        minWindPrefab = skillManager.CreatePrefab(clonePrefabIndex, new Vector3(player.transform.position.x, player.transform.position.y -0.16f), Quaternion.Euler(180, 0, 0)).GetComponent<MinWindPrefab>();
    }

    public override void SkillUpdate()
    {
        base.SkillUpdate();
        //动画播放完毕后再转换状态。
        if (player.stateMachine.currentState.animOverTrigger && player.stateMachine.currentState == player.skillState)
        {
            player.canAttack = true;
            player.anim.SetBool("Wind", false);
            player.canDash = true;
            player.stateMachine.ChangeState(player.floatState);
        }
        if (time > 5f)
        {
            minWindPrefab.Dead();
            isUseSkill = false;
            minWindPrefab = null;
            time = 0;
        }
    }
}
