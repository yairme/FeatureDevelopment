using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;

    private Path _path;
    private WayPoints _currentWaypoint;

    private void Start()
    {
        SetupPath();
    }

    private void SetupPath()
    {
        _path = FindObjectOfType<Path>();
        _currentWaypoint = _path.GetPathStart();
    }


    private void FixedUpdate()
    {
        transform.Translate(translation: Vector3.forward * _speed * Time.deltaTime);
        float distanceToWaypoint = Vector3.Distance(transform.position, _currentWaypoint.GetPosition());
        if (distanceToWaypoint <= _arrivalThreshold)
        {
            if (_currentWaypoint == _path.GetPathEnd())
            {
                PathComplete();
            }
            else
            {
                _currentWaypoint = _path.GetNextWaypoint(_currentWaypoint);
                transform.LookAt(_currentWaypoint.GetPosition());
            }
        }
    }
    private void PathComplete()
    {
        print("Ending");
        FindObjectOfType<PlayerHealthComponent>().TakeDamage(damage: 1);
        Destroy(gameObject);
    }
}
