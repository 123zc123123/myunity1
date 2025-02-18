using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleNPCBase :NPCDictionBase
{
    [SerializeField] protected int dictionIndex;
    [SerializeField] protected int oldIndex;
    [SerializeField] protected NPCDiction[] npcDictions;

    [SerializeField] protected GameObject promptWord;
    protected virtual void Update()
    {
        if (PuaseManager.instance.isPause)
            return;
        //����Ի�����֮����ã�����ض���ť��ʼ�Ի���
        if (canDiction && Input.GetKeyDown(KeyCode.F) && !isDiction)
        {
            promptWord.SetActive(false);
            if (dictionType != DictionType.Signs)
            {
                dictionController.SetActivatePanel(true, true);
            }
            else
            {
                dictionController.SetActivatePanel(true, false);
            }
            isDiction = true;
            dictionController.SetText(npcDictions[dictionIndex].npcDiction, npcDictions[dictionIndex].nextIndex, npcDictions[dictionIndex].npcName);
            player.stateMachine.ChangeState(player.dictionState);
            oldIndex = dictionIndex;
            dictionIndex = npcDictions[dictionIndex].nextIndex;

        }

        //�Ի�;�е�������������ȫ������һ�Σ����δ������ȫ������ټ���
        if (isDiction && dictionController.textAppearOver && Input.GetKeyDown(KeyCode.Mouse0) && !dictionController.dictionOver)
        {
            dictionController.SetText(npcDictions[dictionIndex].npcDiction, npcDictions[dictionIndex].nextIndex, npcDictions[dictionIndex].npcName);
            oldIndex = dictionIndex;
            dictionIndex = npcDictions[dictionIndex].nextIndex;
        }
        else if (isDiction && !dictionController.textAppearOver && Input.GetKeyDown(KeyCode.Mouse0) && !dictionController.dictionOver)
        {
            dictionController.FastSetText(npcDictions[oldIndex].npcDiction, npcDictions[oldIndex].nextIndex);
        }

        //�Ի�����
        if (dictionController.dictionOver && Input.GetKeyDown(KeyCode.Mouse0)&&isDiction)
        {
            dictionController.SetActivatePanel(false, false);
            dictionIndex = 0;
            isDiction = false;
            dictionController.dictionOver = false;
            StartCoroutine(WaitForContinue());
        }
    }

    //��һ������״̬����֤�����ҷż��ܡ�
    IEnumerator WaitForContinue()
    {
        yield return new WaitForSeconds(0.5f);
        player.stateMachine.ChangeState(player.idleState);
    }
}
