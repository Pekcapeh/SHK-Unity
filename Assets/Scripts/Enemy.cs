using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _radiusCircle = 4;
    [SerializeField] private float _speed = 2;
    private Vector3 _target;
        
    private void Start()
    {
        _target = CreateTarget();
    }
        
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            _target = CreateTarget();
    }

    public Vector3 CreateTarget()
    {
        return Random.insideUnitCircle * _radiusCircle;
    }    
}
