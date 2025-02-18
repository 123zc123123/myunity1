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
    //检测到玩家对象，并且不在放技能的状态，并且玩家不处于无敌状态。
    //如果怪物死亡，则碰撞器失效。
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
