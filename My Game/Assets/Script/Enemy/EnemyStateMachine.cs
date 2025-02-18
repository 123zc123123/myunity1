using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; }

    public bool isChangeState;
    public EnemyState newState { get; private set; }
    //ÉèÖÃ³õÊ¼×´Ì¬
    public void SetStartState(EnemyState _enemyState)
    {
        currentState = _enemyState;
        currentState.EnterState();
        isChangeState = false;
    }
    //×´Ì¬¼äÇĞ»»
    public void ChangeState(EnemyState _enemyState)
    {
        newState = _enemyState;
        isChangeState = true;
        currentState.ExitState();
        _enemyState.EnterState();
        currentState = _enemyState;

    }
}
