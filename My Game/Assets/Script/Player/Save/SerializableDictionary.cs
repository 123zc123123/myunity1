using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//�ǵ�Ҫ�ӿ����л���ǩ�����Ӳ��С�
//�Զ����ֵ��࣬�������л��ͷ����л�,��Ϊ�ֵ�û�����л������Խ��ֵ�ת���������б������л�
public class SerializableDictionary<Tkey,Tvalue> : Dictionary<Tkey,Tvalue>,ISerializationCallbackReceiver
{
    //�������ӣ�Ҫ��Ȼ���л�������⣬Ҫô�͹�����Ҫô�ͼ�[SerializeField]
    [SerializeField]private List<Tkey> keys = new List<Tkey>();
    [SerializeField]private List<Tvalue> values = new List<Tvalue>();

    //�ڷ����л���
    public void OnAfterDeserialize()
    {
        this.Clear();
        if (keys.Count != values.Count) 
        {
            Debug.LogError("��ֵ�Բ�ƥ��");
        }
        for (int i = 0; i < keys.Count; i++) 
        {
            this.Add(keys[i], values[i]);
        }
    }
    //�����л�ǰ�Զ�����
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
