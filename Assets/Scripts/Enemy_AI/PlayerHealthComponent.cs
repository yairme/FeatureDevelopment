using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthComponent : HealthComponent
{

    public void Update()
    {

    }

    protected override void Dead()
    {
        base.Dead();
        print("GameOver");
    }
}
