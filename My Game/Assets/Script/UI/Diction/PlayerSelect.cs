using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���ѡ������ݽṹ
public class PlayerSelect 
{
    public string selectText { get; private set; }

    public string name { get; private set; }
    //�ڼ���ѡ��
    public int selectIndex { get; private set; }

    public int groupIndex { get; private set; }
    //��һ�仰������
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
