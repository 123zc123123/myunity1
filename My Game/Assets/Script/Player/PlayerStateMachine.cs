using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState currentState { get; private set; }

    public bool isChangeState;
    public PlayerState newState { get; private set; }
    //ÉèÖÃ³õÊ¼×´Ì¬
    public void SetStartState(PlayerState _playerState) 
    {
        currentState = _playerState;
        currentState.EnterState();
        isChangeState = false;
    }
    //×´Ì¬¼äÇĞ»»
    public void ChangeState(PlayerState _playerState) 
    {
        newState = _playerState;
        isChangeState = true;
        currentState.ExitState();
        _playerState.EnterState();
        currentState = _playerState;
       
    }
    
}
