using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    
    protected override void Dead()
    {
        base.Dead();
        Destroy(gameObject);
    }
}
