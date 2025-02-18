using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Ground,
    Air,
    GroundAndAir
}
//����Ԥ���壬�������������ڡ�����Ԥ����֮��Ĺ�ϵ������Ԥ������Ϊ�ҵ�Ԥ�����ϡ�
public class PlayerSkill
{
    //��ǰ���������ĸ�������
    public PlayerSkillGroup skillGroup;

    public Player player;

    public SkillType skillType;

    //�����жϼ����Ƿ�����Ҫ��update���������
    public bool isUseSkill;

    public PlayerSkillManager skillManager;

    public int clonePrefabIndex;

    protected float time;

    //�����������������ڷ����ܡ�
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
    //���ܳ�����һЩ����������update�е��õ�����
    public virtual void SkillUpdate() 
    {
        time += Time.deltaTime;
    }
    //���ܴ������е�һЩ����
    public virtual void SkillTrigger() 
    {
        
    }
}
