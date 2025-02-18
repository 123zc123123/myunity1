using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//玩家选项的数据结构
public class PlayerSelect 
{
    public string selectText { get; private set; }

    public string name { get; private set; }
    //第几个选项
    public int selectIndex { get; private set; }

    public int groupIndex { get; private set; }
    //下一句话的索引
    public int nextTextIndex { get; private set; }

    public PlayerSelect(string _selectText, int _selectIndex, int _nextTextIndex, int _groupIndex) 
    {
        selectIndex = _selectIndex;
        selectText = _selectText;
        nextTextIndex = _nextTextIndex;
        groupIndex = _groupIndex;
        name = "Alice";
    }
}
