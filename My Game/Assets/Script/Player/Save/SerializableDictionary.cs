using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//记得要加可序列化标签，不加不行。
//自定义字典类，用于序列化和反序列化,因为字典没法序列化，所以将字典转换成两个列表来序列化
public class SerializableDictionary<Tkey,Tvalue> : Dictionary<Tkey,Tvalue>,ISerializationCallbackReceiver
{
    //这个必须加，要不然序列化会出问题，要么就公开，要么就加[SerializeField]
    [SerializeField]private List<Tkey> keys = new List<Tkey>();
    [SerializeField]private List<Tvalue> values = new List<Tvalue>();

    //在反序列化后
    public void OnAfterDeserialize()
    {
        this.Clear();
        if (keys.Count != values.Count) 
        {
            Debug.LogError("键值对不匹配");
        }
        for (int i = 0; i < keys.Count; i++) 
        {
            this.Add(keys[i], values[i]);
        }
    }
    //在序列化前自动调用
    public void OnBeforeSerialize()
    {
        
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<Tkey,Tvalue> kvp in this) 
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }
}
