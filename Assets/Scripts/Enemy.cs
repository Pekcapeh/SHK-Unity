using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2;
    private Vector3 _target;
        
    private void Start()
    {
        _target = GetTarget();
    }
        
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            _target = GetTarget();
    }

    public Vector3 GetTarget()
    {
        return Random.insideUnitCircle * 4;
    }    
}
