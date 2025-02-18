using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景中的NPC对话,NPC数据结构
public class NPCDiction
{
    public string npcName { get; private set; }

    public string npcDiction { get; private set; }

    //如果不转到玩家选项的话，就是下一句话，如果转到就是转到哪个玩家选项组。
    public int nextIndex { get; private set; }

    public bool isToPlayerSelet { get; private set; }

    //传入的是npc的名字和所说的话以及下一句话的编码
    public NPCDiction(string _npcName,string _npcDiction,int _nextIndex, bool _isToPlayerSelet)
    {
        npcDiction = _npcDiction;
        npcName = _npcName;
        nextIndex = _nextIndex;
        isToPlayerSelet = _isToPlayerSelet;
    }
}
