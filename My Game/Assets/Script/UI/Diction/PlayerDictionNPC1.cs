using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDictionNPC1 : NPCDictionBase
{

    [SerializeField] private NPCDiction[] npcDictions;
    [SerializeField] private PlayerSelect[] playerSelects;
    [SerializeField] private int dictionIndex;
    [SerializeField] private int oldIndex;



    protected override void Start()
    {
        base.Start();
        dictionType = DictionType.NPCAndPlayerDiction;
        canDiction = false;
        dictionIndex = 0;
        oldIndex = 0;
        SetDiction();
    }

    private void Update()
    {
        if (PuaseManager.instance.isPause)
            return;

        //进入对话区间之后调用，点击特定按钮后开始对话。
        if (canDiction && Input.GetKeyDown(KeyCode.F) && !isDiction)
        {
            dictionController.SetActivatePanel(true, true);
            isDiction = true;
            dictionController.SetText(npcDictions[dictionIndex].npcDiction, npcDictions[dictionIndex].nextIndex, npcDictions[dictionIndex].npcName);
            player.stateMachine.ChangeState(player.dictionState);
            oldIndex = dictionIndex;
            dictionIndex = npcDictions[dictionIndex].nextIndex;

        }

        //对话途中点击，如果加载完全，则下一段，如果未加载完全，则快速加载
        //1.是否在对话，用于区分是不是第一次进入，主要控制面板显形，玩家状态设置。
        //2.文本是否完成加载。3.输入。4.对话是否结束。5.是否跳转玩家选项。6.玩家是否在进行选择。
        if (isDiction && dictionController.textAppearOver && Input.GetKeyDown(KeyCode.Mouse0) && !dictionController.dictionOver && !npcDictions[oldIndex].isToPlayerSelet&& !dictionController.isPlayerSelect)
        {
            dictionController.SetText(npcDictions[dictionIndex].npcDiction, npcDictions[dictionIndex].nextIndex, npcDictions[dictionIndex].npcName);
            oldIndex = dictionIndex;
            dictionIndex = npcDictions[dictionIndex].nextIndex;
        }
        else if (isDiction && !dictionController.textAppearOver && Input.GetKeyDown(KeyCode.Mouse0) && !dictionController.dictionOver && !dictionController.isPlayerSelect )
        {
            dictionController.FastSetText(npcDictions[oldIndex].npcDiction, npcDictions[oldIndex].nextIndex);
        }

        //玩家选项显形
        if (npcDictions[oldIndex].isToPlayerSelet && dictionController.textAppearOver&&isDiction ) 
        {
            string[] buttonList = new string[3] { "Null", "Null", "Null" };
            int index = 0;
            for (int i = 0; i < playerSelects.Length; i++) 
            {
                if (playerSelects[i].groupIndex == npcDictions[oldIndex].nextIndex) 
                {
                    buttonList[index] = playerSelects[i].selectText;
                    index++;
                }
            }

            dictionController.SetButton(true, buttonList[0], buttonList[1], buttonList[2]);
        }

        //选项后调用
        if (dictionController.buttonIndex != -1) 
        {
            dictionController.SetButton(false);
            for (int i = 0; i < playerSelects.Length; i++)
            {
                if (playerSelects[i].groupIndex == npcDictions[oldIndex].nextIndex&&playerSelects[i].selectIndex== dictionController.buttonIndex)
                {
                    dictionIndex = playerSelects[i].nextTextIndex;
                    dictionController.SetText(npcDictions[dictionIndex].npcDiction, npcDictions[dictionIndex].nextIndex, npcDictions[dictionIndex].npcName);
                    oldIndex = dictionIndex;
                    dictionIndex = npcDictions[dictionIndex].nextIndex;
                }
            }
            dictionController.buttonIndex = -1;
            dictionController.isPlayerSelect = false;
        }

        //对话结束
        if (dictionController.dictionOver && Input.GetKeyDown(KeyCode.Mouse0)&&isDiction)
        {
            dictionController.SetActivatePanel(false, false);
            dictionIndex = 0;
            StartCoroutine(WaitForContinue());
            isDiction = false;
            dictionController.dictionOver = false;
        }
    }
    private void SetDiction()
    {
        npcDictions = new NPCDiction[8];
        npcDictions[0] = new NPCDiction("John", "Welcome to the tavern, what would you like to drink?", 0, true);
        npcDictions[1] = new NPCDiction("John", "No jokes, buddy, we don't have that here.", 2, false);
        npcDictions[2] = new NPCDiction("John", "We only have intoxicating cocktails and exhilarating vodka here.", 3, false);
        npcDictions[3] = new NPCDiction("Emma", "What's going on? What did the guest order?", 1, true);
        npcDictions[4] = new NPCDiction("Emma", "If you don't want to be thrown out by us, don't mention that damned thing.", -1, false);
        npcDictions[5] = new NPCDiction("John", "Brother, you have great taste.This is our signature drink.", 6, false);
        npcDictions[6] = new NPCDiction("John", "Here you go, I wish you enjoy your drink.", -1, false);
        npcDictions[7] = new NPCDiction("Emma", "John,here's the drink for this gentleman, just as he requested.", -1, false);

        playerSelects = new PlayerSelect[5];
        playerSelects[0] = new PlayerSelect("I want a gun.", 0, 1, 0);
        playerSelects[1] = new PlayerSelect("I would like a vodka, with ice.", 1, 5, 0);
        playerSelects[2] = new PlayerSelect("Do you sell weapons here?", 0, 4, 1);
        playerSelects[3] = new PlayerSelect("I've changed my mind. I'd like a glass of iced brandy instead.", 1, 7, 1);
        playerSelects[4] = new PlayerSelect("I've changed my mind. I'd like a glass of iced brandy instead.", 2, 7, 0);

    }
    //等一下再切状态，保证不会乱放技能。
    IEnumerator WaitForContinue()
    {
        yield return new WaitForSeconds(0.5f);
        player.stateMachine.ChangeState(player.idleState);
    }
}
