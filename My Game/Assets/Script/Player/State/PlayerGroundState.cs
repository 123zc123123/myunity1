using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(string _stateName, string _animName, Player _player) : base(_stateName, _animName, _player)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        //�������״̬�󣬾Ϳ�����Ծ
        player.canJump = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Input.GetKeyDown(KeyCode.Mouse0) && player.canAttack)
        {
            if (player.attackTime > 3)
                player.attackCount = 0;
            player. attackTime = 0;
            player.canAttack = false;
            stateMachine.ChangeState(player.attackState);

        }
        
        //Input.GetKeyDown(dataBase.keyControllerPair["Jump"])�����������ָ���Ĵ��棬��ͷ���޸�
        //��ԾҪ�����������������룬��������û�ڲ�������
        if (Input.GetKeyDown(KeyCode.Space) && player. canJump&&animOverTrigger)
        {
            stateMachine.ChangeState(player.jumpState);
        }
        //�Ӹߴ����������ߡ�
        if (player.canJump && !player.DeteGround())
        {
            stateMachine.ChangeState(player.fallState);
        }
        if (player.canDefense && Input.GetKeyDown(KeyCode.N)) 
        {
            stateMachine.ChangeState(player.defenseState);
        }

      
    }
}
