using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGroup : PlayerSkillGroup
{
    public bool canUseWindSkill;

    public WindGroup(Player _player, string _name) : base(_player, _name)
    {
        canUseWindSkill = true;
    }

    public override PlayerSkill SkillTrigger(KeyCode _key1, KeyCode _key2)
    {
        PlayerSkill currentSkill = null;
        //在空中只能释放一次风类技能
        if (!canUseWindSkill)
        {
            player.stateMachine.ChangeState(player.idleState);
            return currentSkill;
        }
        canUseWindSkill = false;
        foreach (var skillAndKeyCodeList in skillAndKeys)
        {
            if (_key1 == skillAndKeyCodeList.Value[0] && _key2 == skillAndKeyCodeList.Value[1])
            {
                skillAndKeyCodeList.Key.SkillTrigger();
                currentSkill = skillAndKeyCodeList.Key;
            }
        }
        return currentSkill;
    }
    public override void SkillUpdate()
    {
        base.SkillUpdate();
        if (player.DeteGround()) 
        {
            canUseWindSkill = true;
        }
    }
}
