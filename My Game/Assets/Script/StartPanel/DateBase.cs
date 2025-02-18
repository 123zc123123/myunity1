using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataBase")]
public class DataBase : ScriptableObject
{
    //后续应该在一开始就从储存文件中读取玩家的设置
    public Dictionary<string, KeyCode> keyControllerPair = new Dictionary<string, KeyCode>();
}

