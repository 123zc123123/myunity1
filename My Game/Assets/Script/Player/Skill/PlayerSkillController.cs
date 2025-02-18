using UnityEngine;

public class PlayerSkillController
{
    //技能
    public PlayerSkillGroup skill1CurrentSkillGroup;
    public PlayerSkillGroup skill2CurrentSkillGroup;
    public PlayerSkillGroup skill3CurrentSkillGroup;

    //当前可以使用的技能组
    public PlayerSkillGroup[] canUseSkillGroups;
    public int canUseSkillGroupsIndex;


    //public PlayerSkillGroup[] backupSkillGroups;
    //当前可替换的下一组技能
    //public PlayerSkillGroup currentBackupSkillGroup;
    //public int backupSkillGroupIndex;


    //设置初始技能组，可用于多组技能。
    public void SetStartSkillGroup(PlayerSkillGroup _mouse0SkillGroup,PlayerSkillGroup _skill2)
    {
        //注释掉的部分是用于单个技能组切换的
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

    //替换当前可替换的备用技能
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


    //替换当前技能
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
