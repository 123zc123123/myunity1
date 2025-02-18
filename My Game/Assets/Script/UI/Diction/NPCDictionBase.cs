using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DictionType 
{
    singleNPCDiction,
    NPCAndPlayerDiction,
    Signs
}
//所有对话NPC行为的基类
public class NPCDictionBase : MonoBehaviour
{
    public bool canDiction;
    public DictionType dictionType;
    public Player player;
    public DictionController dictionController;
    public bool isDiction;

    
    protected virtual void Start()
    {
        player = PlayerManeger.instance.player;
        dictionController = DictionController.instance;
        isDiction = false;
    }


   

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == true)
            canDiction = true;
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == true)
            canDiction = false;
    }
}
