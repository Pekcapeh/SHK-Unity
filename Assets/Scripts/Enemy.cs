using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2;
    private Vector3 _target;
        
    private void Start()
    {
        MoveTarget();
    }
        
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            MoveTarget();
    }

    public void MoveTarget()
    {
        _target = Random.insideUnitCircle * 4;
    }    
}
