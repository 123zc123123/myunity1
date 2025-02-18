using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����еķ糡�������������ķ糡�����������
public class MinWindPrefab : MonoBehaviour
{
    [SerializeField]private Player player;

    private void Start()
    {
        player = PlayerManeger.instance.player;
    }
    //�����糡��
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null) 
        {
            player.stateMachine.ChangeState(player.fallState);
        }
    }
    //�ӱ�����糡
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null&&(player.stateMachine.currentState==player.jumpState|| player.stateMachine.currentState == player.fallState))
        {
            player.stateMachine.ChangeState(player.floatState);
        }
    }
    //�ڷ糡����Ծ
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
