using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxHit : MonoBehaviour
{
    private Player player;

    private BaseEnemy enemy;
    private void Start()
    {
        player = PlayerManeger.instance.player;
        enemy = GetComponentInParent<BaseEnemy>();
    }
    //��⵽��Ҷ��󣬲��Ҳ��ڷż��ܵ�״̬��������Ҳ������޵�״̬��
    //�����������������ײ��ʧЧ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null&&player.stateMachine.currentState!=player.skillState&&player.canHurt&&enemy.isDead==false) 
        {
            enemy.enemyAtrribute.DoDamage(player.playerAttribute);
        }
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null && player.stateMachine.currentState != player.skillState&&player.canHurt && enemy.isDead == false)
        {
            enemy.enemyAtrribute.DoDamage(player.playerAttribute);
        }
    }
}
