using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����е�NPC�Ի�,NPC���ݽṹ
public class NPCDiction
{
    public string npcName { get; private set; }

    public string npcDiction { get; private set; }

    //�����ת�����ѡ��Ļ���������һ�仰�����ת������ת���ĸ����ѡ���顣
    public int nextIndex { get; private set; }

    public bool isToPlayerSelet { get; private set; }

    //�������npc�����ֺ���˵�Ļ��Լ���һ�仰�ı���
    public NPCDiction(string _npcName,string _npcDiction,int _nextIndex, bool _isToPlayerSelet)
    {
        npcDiction = _npcDiction;
        npcName = _npcName;
        nextIndex = _nextIndex;
        isToPlayerSelet = _isToPlayerSelet;
    }
}
