using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase")]
public class DataBase : ScriptableObject
{
    //����Ӧ����һ��ʼ�ʹӴ����ļ��ж�ȡ��ҵ�����
    public Dictionary<string, KeyCode> keyControllerPair = new Dictionary<string, KeyCode>();
}

