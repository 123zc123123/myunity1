using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//此类用于保存所有的数据,后续可更改
public class SaveStruct 
{
    //玩家数据
    public List<string> unlockPlayerSkillGroup;//技能是否解锁
    public SerializableDictionary<int, string> keyCodeAndSkill;//按键是否绑定技能
    public int saveLoader;//最后存档点
    public SerializableDictionary<string,int> dataBaseDict;//玩家自定义的按键
    public SerializableDictionary<string, float> playerAttributes;//玩家的状态
    //场景数据
    public string sceneName;

    public bool[] doorIsTrigger;
    public SaveStruct() 
    {
        unlockPlayerSkillGroup = new List<string>();
        keyCodeAndSkill = new SerializableDictionary<int, string>();
        saveLoader = -1;
        dataBaseDict = new SerializableDictionary<string, int>();
        playerAttributes = new SerializableDictionary<string, float>();
        sceneName = "FirstName";
        doorIsTrigger = new bool[10];
    }
}
