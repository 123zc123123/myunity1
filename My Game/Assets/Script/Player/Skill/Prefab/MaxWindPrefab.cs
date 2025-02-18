using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxWindPrefab : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Start()
    {
        player = PlayerManeger.instance.player;
    }
    //击退敌人，与主角击退方向相反。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseEnemy>() != null )
        {
            BaseEnemy enemy = collision.GetComponent<BaseEnemy>();
            if (player.faceRight)
                enemy.rb.velocity=new Vector3(12, enemy.rb.velocity.y);
            else
                enemy.rb.velocity = new Vector3(-12, enemy.rb.velocity.y);
            enemy.stateMachine.ChangeState(enemy.hitState);
        }
    }
    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
