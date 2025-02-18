using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���������
public class PlayerSkillGroup
{
    //�������е����м��ܼ������䰴��
    public Dictionary<PlayerSkill,KeyCode[]> skillAndKeys;

    protected Player player;

    //�����Ƿ����,��Ҫ����UI����ѡ����ʱ���Ƿ���ѡ��
    public bool isUnlock;

    public string name;
    public PlayerSkillGroup(Player _player,string _name)
    {
        player = _player;
        name = _name;
        isUnlock = false;
    }
    //���ڼ��ܸļ�
    public virtual void ChangeSkillKeys(PlayerSkill _playerSkill,KeyCode _switchKey0) 
    {
        skillAndKeys[_playerSkill][0] = _switchKey0;
    }

    //����Ҫ���ⲿ��Ӽ���ʱ����ã��������������
    public virtual void AddSkillInGroup(PlayerSkill _playerSkill,KeyCode _key1,KeyCode _key2) 
    {
        if (skillAndKeys == null)
            skillAndKeys = new Dictionary<PlayerSkill, KeyCode[]>();
        KeyCode[] keys = new KeyCode[2];
        keys[0]=_key1;
        keys[1]=_key2;
        skillAndKeys[_playerSkill] = keys;
    }
    //��ǰ������Ҫ����������update�е����ݡ�
    public virtual void SkillUpdate() 
    {
        foreach (var playerSkill in skillAndKeys.Keys) 
        {
            if (playerSkill.isUseSkill)
                playerSkill.SkillUpdate();
        }
        
    }
    //��������϶��������ͷż��ܵ�ʱ�������Ҹü��ܴ��ڡ�
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
    //�Ƿ���ڼ���
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
