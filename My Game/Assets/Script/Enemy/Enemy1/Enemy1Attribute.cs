using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Attribute : EnemyAttribute
{
    private Enemy1 enemy1;

    private void Start()
    {
        enemy1 = GetComponent<Enemy1>();
        SetInitValue(100, 1, 20);
        
    }
}
