using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if(GetState() != EnemyState.Death)
        {
            Act();
        }
    }

    protected override void Act()
    {
        NormalAction();
        AttackAction(20.0f, 3.0f);
        nav.SetDestination(target.transform.position);
    }
}
