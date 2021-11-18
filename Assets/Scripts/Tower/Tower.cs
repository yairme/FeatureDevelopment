using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyRangeChecker))]
public class Tower : MonoBehaviour
{
    [SerializeField] private Transform _turret;
    [SerializeField] private float _damageAmount = 5;
    [SerializeField] private float _shootcooldown = 0.5f;

    private EnemyRangeChecker _enemyInRangeChecker;
    private float _nextShootTime = 0;

    private void Start()
    {
        _enemyInRangeChecker = GetComponent<EnemyRangeChecker>();
    }

    private void Update()
    {
        Enemy enemy = _enemyInRangeChecker.GetFirstEnemyInRange();
        if (enemy != null)
        {
            _turret.LookAt(enemy.transform);
            if (CanShoot())
            {
                enemy.GetHealthComponent().TakeDamage(_damageAmount);
                _nextShootTime = Time.time + _shootcooldown;
            }
        }
    }
   
    private bool CanShoot()
    {
        return Time.time >= _nextShootTime; 
    }
}
