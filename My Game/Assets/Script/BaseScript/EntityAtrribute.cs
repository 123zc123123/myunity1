using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAtrribute:MonoBehaviour
{
    public AtrributeType maxHp;
    public AtrributeType currentHp;
    //攻击力和护甲，护甲可以用来做减伤。
    public AtrributeType attack;
    public AtrributeType armor;

    protected virtual void Awake()
    {
        maxHp = new AtrributeType("maxHp");
        currentHp = new AtrributeType("currentHp");
        attack = new AtrributeType("attack");
        armor = new AtrributeType("armor");
    }

    //设置初始数值
    public virtual void SetInitValue(float _maxHp, float _attack, float _armor) 
    {
        maxHp.SetValue(_maxHp);
        currentHp.SetValue(_maxHp);
        armor.SetValue(_armor);
        attack.SetValue(_attack);
    }
    //根据传入的bool值来判断加减，传进来的float值统一为正。
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

    //需要造成伤害时调用，传入受伤的目标和伤害数值，调用受伤目标的减法函数来造成伤害。
    //伤害数值可以先进行计算后再传入函数。
    //传入的变量的目的在于，传入的变量相当于一个数值载体，通过改变该数值载体来进行伤害等操作。
    //可以根据不同的技能传入不同的伤害，后续也可以改为传入百分比。
    public virtual void DoDamage(EntityAtrribute _entity, float _damage = -1)
    {
        //伤害减免计算
        //最终伤害
        float lastDamageValue;
        //伤害
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
        //造成伤害
        _entity.ChangeAtrributeValue(_entity.currentHp, lastDamageValue, false);
        Debug.Log(_entity.currentHp.GetValue());
    }

    //治疗，预想是可以自身可以其他人
    public virtual void CureHealth(EntityAtrribute _entity, float _value) 
    {
        _entity.ChangeAtrributeValue(currentHp, _value, true);
    }
}
