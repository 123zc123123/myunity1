using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute :EntityAtrribute,ISave
{ 
    private void Start()
    {
        SetInitValue(6, 5, 0);
    }
    public override void DoDamage(EntityAtrribute _entity, float _damage = -1)
    {
        if(_entity.GetComponent<BaseEnemy>().stateMachine.currentState!= _entity.GetComponent<BaseEnemy>().hitState)
            _entity.GetComponent<BaseEnemy>().stateMachine.ChangeState(_entity.GetComponent<BaseEnemy>().hitState);
        base.DoDamage(_entity, _damage);

    }

    public void Save(ref SaveStruct _saveDate)
    {
        _saveDate.playerAttributes["Attack"] = attack.GetValue();
        _saveDate.playerAttributes["MaxHP"] = maxHp.GetValue();
    }

    public void Load(SaveStruct _loadDate)
    {
        if (_loadDate.playerAttributes.ContainsKey("MaxHP"))
        {
            maxHp.SetValue(_loadDate.playerAttributes["MaxHP"]);
        }
        if (_loadDate.playerAttributes.ContainsKey("Attack"))
            attack.SetValue(_loadDate.playerAttributes["Attack"]);
    }
}
