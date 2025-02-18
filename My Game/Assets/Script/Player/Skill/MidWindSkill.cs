using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//击退敌人，并且稍微击退自身
public class MidWindSkill : PlayerSkill
{
    public MaxWindPrefab midWindPrefab;
    public float gravityScale;
    
    public MidWindSkill(Player _player, SkillType _skillType, PlayerSkillManager _skillManager, PlayerSkillGroup _skillGroup = null) : base(_player, _skillType, _skillManager, _skillGroup)
    {
        animTrigger = "Wind";
        gravityScale = player.rb.gravityScale;
    }

    public override void SkillTrigger()
    {
        base.SkillTrigger();
        if (midWindPrefab != null)
        {
            player.canAttack = true;
            player.stateMachine.ChangeState(player.idleState);
            return;
        }
        player.anim.SetBool("Wind", true);
        player.rb.gravityScale=0;
        player.canDash = false;
        isUseSkill = true;
    }

    public void CreateWind()
    {
        clonePrefabIndex = 2;
        if (player.faceRight)
        {
            midWindPrefab = skillManager.CreatePrefab(clonePrefabIndex, new Vector3(player.transform.position.x + 0.58f, player.transform.position.y), Quaternion.identity).GetComponent<MaxWindPrefab>();
            player.rb.velocity=new Vector2(-6, 0);
        }
        else
        { 
            midWindPrefab = skillManager.CreatePrefab(clonePrefabIndex, new Vector3(player.transform.position.x - 0.58f, player.transform.position.y), Quaternion.Euler(0, 180, 0)).GetComponent<MaxWindPrefab>();
            player.rb.velocity = new Vector2(6, 0);
        }

    }

    public override void SkillUpdate()
    {
        
        base.SkillUpdate();
        //动画播放完毕后再转换状态。
        if (player.stateMachine.currentState.animOverTrigger&&player.stateMachine.currentState==player.skillState) 
        {
            player.canAttack = true;
            player.anim.SetBool("Wind", false);
            player.rb.gravityScale = gravityScale;
            player.canDash = true;
        }

        if (time >0.5f ) 
        {
            if (player.stateMachine.currentState == player.skillState)
                player.stateMachine.ChangeState(player.idleState);
            midWindPrefab.Dead();
            isUseSkill = false;
            midWindPrefab = null;
            time = 0;
        }
    }
    
    
}
