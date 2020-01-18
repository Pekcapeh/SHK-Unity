using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
        
    void Start()
    {
        Target();
    }
        
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, 2 * Time.deltaTime);
        if (transform.position == _target)
            Target();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }

    public void Target()
    {
        _target = Random.insideUnitCircle * 4;
    }
}
