using UnityEngine;

public class PlayerSkillController
{
    //����
    public PlayerSkillGroup skill1CurrentSkillGroup;
    public PlayerSkillGroup skill2CurrentSkillGroup;
    public PlayerSkillGroup skill3CurrentSkillGroup;

    //��ǰ����ʹ�õļ�����
    public PlayerSkillGroup[] canUseSkillGroups;
    public int canUseSkillGroupsIndex;


    //public PlayerSkillGroup[] backupSkillGroups;
    //��ǰ���滻����һ�鼼��
    //public PlayerSkillGroup currentBackupSkillGroup;
    //public int backupSkillGroupIndex;


    //���ó�ʼ�����飬�����ڶ��鼼�ܡ�
    public void SetStartSkillGroup(PlayerSkillGroup _mouse0SkillGroup,PlayerSkillGroup _skill2)
    {
        //ע�͵��Ĳ��������ڵ����������л���
        //backupSkillGroups = new PlayerSkillGroup[3];
        //backupSkillGroups[0] = _backupSkillGroup1;
        //backupSkillGroups[1] = _backupSkillGroup2;
        //backupSkillGroups[2] = _backupSkillGroup3;
        //currentBackupSkillGroup = _backupSkillGroup1;
        //backupSkillGroupIndex = 0;

        skill1CurrentSkillGroup = _mouse0SkillGroup;
        skill2CurrentSkillGroup = _skill2;
        canUseSkillGroups = new PlayerSkillGroup[5];
        canUseSkillGroupsIndex = 0;
        canUseSkillGroups[canUseSkillGroupsIndex] = _mouse0SkillGroup;
        canUseSkillGroupsIndex += 1;
        canUseSkillGroups[canUseSkillGroupsIndex] = _skill2;
        canUseSkillGroupsIndex += 1;
        _mouse0SkillGroup.isUnlock = true;
        _skill2.isUnlock = true;
    }

    //�滻��ǰ���滻�ı��ü���
    // public void ChangecurrentBackupSkillGroup() 
    //{
    //   backupSkillGroupIndex += 1;
    //   if (backupSkillGroupIndex > 2) 
    //      {
    //           backupSkillGroupIndex = 0;
    //      }
    //   currentBackupSkillGroup = backupSkillGroups[backupSkillGroupIndex];
    //}


    public void UnlockSkillGroup(PlayerSkillGroup _skillGroup) 
    {
        canUseSkillGroups[canUseSkillGroupsIndex] = _skillGroup;
        canUseSkillGroupsIndex += 1;
        _skillGroup.isUnlock = true;
    }


    //�滻��ǰ����
    public void SwitchCurrentSkillGroup(string _keyName,PlayerSkillGroup _switchSkillGroup,KeyCode _keyCode)
    {
        switch (_keyName) 
        {
            case "Skill1":
                skill1CurrentSkillGroup = _switchSkillGroup;
                foreach (PlayerSkill skill in _switchSkillGroup.skillAndKeys.Keys)
                {
                    _switchSkillGroup.ChangeSkillKeys(skill, _keyCode);
                }
                break;
            case "Skill2":
                skill2CurrentSkillGroup = _switchSkillGroup;
                foreach (PlayerSkill skill in _switchSkillGroup.skillAndKeys.Keys)
                {
                    _switchSkillGroup.ChangeSkillKeys(skill, _keyCode);
                }
                break;
            case "Skill3":
                skill2CurrentSkillGroup = _switchSkillGroup;
                foreach (PlayerSkill skill in _switchSkillGroup.skillAndKeys.Keys)
                {
                    _switchSkillGroup.ChangeSkillKeys(skill, _keyCode);
                }
                break;
        }
        //PlayerSkillGroup switchSkillGroup;
        //switchSkillGroup = backupSkillGroups[backupSkillGroupIndex];
        //backupSkillGroups[backupSkillGroupIndex] = currentSkillGroup;
        //currentSkillGroup = switchSkillGroup;
    }


    public void SkillUpdate() 
    {
        
        for (int i = 0; i < canUseSkillGroupsIndex; i++) 
        {
            canUseSkillGroups[i].SkillUpdate();
        }
    }
}
