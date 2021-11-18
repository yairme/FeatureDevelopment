using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class Enemy : MonoBehaviour
{

    private HealthComponent _healthcomponet;
    void Start()
    {
        _healthcomponet = GetComponent<HealthComponent>();
    }

    public  HealthComponent GetHealthComponent()
    {
        return _healthcomponet;
    }

}
