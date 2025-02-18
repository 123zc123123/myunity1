using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//技能组基类
public class PlayerSkillGroup
{
    //技能组中的所有技能集合与其按键
    public Dictionary<PlayerSkill,KeyCode[]> skillAndKeys;

    protected Player player;

    //技能是否解锁,主要用于UI界面选择技能时候是否能选择。
    public bool isUnlock;

    public string name;
    public PlayerSkillGroup(Player _player,string _name)
    {
        player = _player;
        name = _name;
        isUnlock = false;
    }
    //用于技能改键
    public virtual void ChangeSkillKeys(PlayerSkill _playerSkill,KeyCode _switchKey0) 
    {
        skillAndKeys[_playerSkill][0] = _switchKey0;
    }

    //当需要从外部添加技能时候调用，方便后续操作。
    public virtual void AddSkillInGroup(PlayerSkill _playerSkill,KeyCode _key1,KeyCode _key2) 
    {
        if (skillAndKeys == null)
            skillAndKeys = new Dictionary<PlayerSkill, KeyCode[]>();
        KeyCode[] keys = new KeyCode[2];
        keys[0]=_key1;
        keys[1]=_key2;
        skillAndKeys[_playerSkill] = keys;
    }
    //当前技能需要持续存在在update中的内容。
    public virtual void SkillUpdate() 
    {
        foreach (var playerSkill in skillAndKeys.Keys) 
        {
            if (playerSkill.isUseSkill)
                playerSkill.SkillUpdate();
        }
        
    }
    //如果进来肯定就是能释放技能的时机，并且该技能存在。
    public virtual PlayerSkill SkillTrigger(KeyCode _key1, KeyCode _key2) 
    {
        Debug.Log(2);
        PlayerSkill currentSkill=null;
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
    //是否存在技能
    public virtual bool HaveSkill(KeyCode _key1, KeyCode _key2) 
    {
        foreach (var skillAndKeyCodeList in skillAndKeys)
        {
            if (_key1 == skillAndKeyCodeList.Value[0] && _key2 == skillAndKeyCodeList.Value[1])
            {
                return true;
            }
        }
        return false;
    }

    
}
