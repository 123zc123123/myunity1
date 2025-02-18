using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFX : MonoBehaviour
{
    public BaseEnemy enemy;
    public Player player;
    private void Start()
    {
        enemy = GetComponentInParent<BaseEnemy>();
        player = PlayerManeger.instance.player;
    }

    private void AnimationOver()
    {
        enemy.DeteTrigger();
    }

    private void DoDamage() 
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackTransform.position, enemy.attackDeteRadius);
        foreach (var collider in colliders) 
        {
            if (collider.GetComponent<Player>() != null&&player.canHurt) 
            {
                enemy.enemyAtrribute.DoDamage(player.playerAttribute);
            }
        }
    }
}
