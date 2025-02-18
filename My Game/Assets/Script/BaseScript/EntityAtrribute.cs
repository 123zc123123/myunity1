using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAtrribute:MonoBehaviour
{
    public AtrributeType maxHp;
    public AtrributeType currentHp;
    //�������ͻ��ף����׿������������ˡ�
    public AtrributeType attack;
    public AtrributeType armor;

    protected virtual void Awake()
    {
        maxHp = new AtrributeType("maxHp");
        currentHp = new AtrributeType("currentHp");
        attack = new AtrributeType("attack");
        armor = new AtrributeType("armor");
    }

    //���ó�ʼ��ֵ
    public virtual void SetInitValue(float _maxHp, float _attack, float _armor) 
    {
        maxHp.SetValue(_maxHp);
        currentHp.SetValue(_maxHp);
        armor.SetValue(_armor);
        attack.SetValue(_attack);
    }
    //���ݴ����boolֵ���жϼӼ�����������floatֵͳһΪ����
    public virtual void ChangeAtrributeValue(AtrributeType _atrribute,float _value,bool _isAdd) 
    {
        if (_isAdd)
        {
            if (_atrribute == currentHp && currentHp.GetValue() + _value > maxHp.GetValue())
            {
                currentHp.SetValue(maxHp.GetValue());
                return;
            }
            _atrribute.AddValue(_value);
        }
        else
        {
            _atrribute.SubValue(_value);
        }
    }

    //��Ҫ����˺�ʱ���ã��������˵�Ŀ����˺���ֵ����������Ŀ��ļ�������������˺���
    //�˺���ֵ�����Ƚ��м�����ٴ��뺯����
    //����ı�����Ŀ�����ڣ�����ı����൱��һ����ֵ���壬ͨ���ı����ֵ�����������˺��Ȳ�����
    //���Ը��ݲ�ͬ�ļ��ܴ��벻ͬ���˺�������Ҳ���Ը�Ϊ����ٷֱȡ�
    public virtual void DoDamage(EntityAtrribute _entity, float _damage = -1)
    {
        //�˺��������
        //�����˺�
        float lastDamageValue;
        //�˺�
        float damage;
        if (_damage != -1)
            damage = _damage;
        else
            damage = attack.GetValue();
        if (_entity.armor.GetValue() > 0)
            lastDamageValue = damage * (1 - _entity.armor.GetValue() / 100);
        else
            lastDamageValue = damage;
        lastDamageValue = Mathf.Round(lastDamageValue);
        //����˺�
        _entity.ChangeAtrributeValue(_entity.currentHp, lastDamageValue, false);
        Debug.Log(_entity.currentHp.GetValue());
    }

    //���ƣ�Ԥ���ǿ����������������
    public virtual void CureHealth(EntityAtrribute _entity, float _value) 
    {
        _entity.ChangeAtrributeValue(currentHp, _value, true);
    }
}
