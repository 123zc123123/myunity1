using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景中的风场和玩家自身产生的风场均用这个代码
public class MinWindPrefab : MonoBehaviour
{
    [SerializeField]private Player player;

    private void Start()
    {
        player = PlayerManeger.instance.player;
    }
    //跳出风场了
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null) 
        {
            player.stateMachine.ChangeState(player.fallState);
        }
    }
    //从别处跳入风场
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null&&(player.stateMachine.currentState==player.jumpState|| player.stateMachine.currentState == player.fallState))
        {
            player.stateMachine.ChangeState(player.floatState);
        }
    }
    //在风场中跳跃
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null && (player.stateMachine.currentState == player.jumpState || player.stateMachine.currentState == player.fallState))
        {
            player.stateMachine.ChangeState(player.floatState);
        }
    }
    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
