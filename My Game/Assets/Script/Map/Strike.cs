using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : EnemyAttribute
{
    private Player player;
    private void Start()
    {
        player = PlayerManeger.instance.player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null && player.canHurt) 
        {
            player.canJump = true;
            DoDamage(player.playerAttribute,1);

        }
    }
}
