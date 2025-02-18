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
        //进入对话区间之后调用，点击特定按钮后开始对话。
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

        //对话途中点击，如果加载完全，则下一段，如果未加载完全，则快速加载
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

        //对话结束
        if (dictionController.dictionOver && Input.GetKeyDown(KeyCode.Mouse0)&&isDiction)
        {
            dictionController.SetActivatePanel(false, false);
            dictionIndex = 0;
            isDiction = false;
            dictionController.dictionOver = false;
            StartCoroutine(WaitForContinue());
        }
    }

    //等一下再切状态，保证不会乱放技能。
    IEnumerator WaitForContinue()
    {
        yield return new WaitForSeconds(0.5f);
        player.stateMachine.ChangeState(player.idleState);
    }
}
