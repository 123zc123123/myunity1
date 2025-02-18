using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : EntityAtrribute
{
    public override void DoDamage(EntityAtrribute _entity, float _damage = -1)
    {
        _entity.GetComponent<Player>().stateMachine.ChangeState(_entity.GetComponent<Player>().hurtState);
        
        base.DoDamage(_entity, _damage);
        if(_damage!=-1)
            HPUIManager.instance.DecreaseHP((int)_entity.currentHp.GetValue(), (int)_damage);
        else
            HPUIManager.instance.DecreaseHP((int)_entity.currentHp.GetValue(), (int)attack.GetValue());
        Debug.Log(10);
    }
}
