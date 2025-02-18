using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentState { get; private set; }

    public bool isChangeState;
    public PlayerState newState { get; private set; }
    //���ó�ʼ״̬
    public void SetStartState(PlayerState _playerState) 
    {
        currentState = _playerState;
        currentState.EnterState();
        isChangeState = false;
    }
    //״̬���л�
    public void ChangeState(PlayerState _playerState) 
    {
        newState = _playerState;
        isChangeState = true;
        currentState.ExitState();
        _playerState.EnterState();
        currentState = _playerState;
       
    }
    
}
