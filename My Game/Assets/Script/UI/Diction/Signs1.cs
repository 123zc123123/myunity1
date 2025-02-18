using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs1 : SingleNPCBase
{
    
    protected override void Start()
    {
        base.Start();
        dictionType = DictionType.Signs;
        canDiction = false;
        dictionIndex = 0;
        oldIndex = 0;
        SetDiction();
    }
    private void SetDiction()
    {
        npcDictions = new NPCDiction[2];
        npcDictions[0] = new NPCDiction("Null", "鼠标左键为攻击，Q为技能1，E为技能2，shift为冲刺，空格为跳跃。", 1, false);
        npcDictions[1] = new NPCDiction("Null", "QW,WE,SE,能触发额外技能，椅子旁F存档，ESC为暂停。", -1, false);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        promptWord.SetActive(true);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        promptWord.SetActive(false);
    }
}
