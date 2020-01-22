using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2;
    private Vector3 _target;
        
    private void Start()
    {
        TargetMove();
    }
        
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position == _target)
            TargetMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }

    public void TargetMove()
    {
        _target = Random.insideUnitCircle * 4;
    }
}
