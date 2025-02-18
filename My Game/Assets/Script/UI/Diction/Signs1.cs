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
        npcDictions[0] = new NPCDiction("Null", "������Ϊ������QΪ����1��EΪ����2��shiftΪ��̣��ո�Ϊ��Ծ��", 1, false);
        npcDictions[1] = new NPCDiction("Null", "QW,WE,SE,�ܴ������⼼�ܣ�������F�浵��ESCΪ��ͣ��", -1, false);
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
