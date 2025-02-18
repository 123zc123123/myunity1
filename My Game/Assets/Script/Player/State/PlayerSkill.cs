using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Ground,
    Air,
    GroundAndAir
}
//创建预制体，控制其生命周期。管理预制体之间的关系，具体预制体行为挂到预制体上。
public class PlayerSkill
{
    //当前技能属于哪个技能组
    public PlayerSkillGroup skillGroup;

    public Player player;

    public SkillType skillType;

    //用于判断技能是否有需要在update里面的内容
    public bool isUseSkill;

    public PlayerSkillManager skillManager;

    public int clonePrefabIndex;

    protected float time;

    //动画器触发器，用于分身技能。
    public string animTrigger;

    public PlayerSkill(Player _player,SkillType _skillType,PlayerSkillManager _skillManager, PlayerSkillGroup _skillGroup=null) 
    {
        skillGroup = _skillGroup;
        player = _player;
        skillType = _skillType;
        skillManager = _skillManager;
        isUseSkill = false;
        time = 0;
    }
    //技能持续的一些操作，放在update中调用的内容
    public virtual void SkillUpdate() 
    {
        time += Time.deltaTime;
    }
    //技能触发进行的一些操作
    public virtual void SkillTrigger() 
    {
        
    }
}
