using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//�������ڱ������е�����,�����ɸ���
public class SaveStruct 
{
    //�������
    public List<string> unlockPlayerSkillGroup;//�����Ƿ����
    public SerializableDictionary<int, string> keyCodeAndSkill;//�����Ƿ�󶨼���
    public int saveLoader;//���浵��
    public SerializableDictionary<string,int> dataBaseDict;//����Զ���İ���
    public SerializableDictionary<string, float> playerAttributes;//��ҵ�״̬
    //��������
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
