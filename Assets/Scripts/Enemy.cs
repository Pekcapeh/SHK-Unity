using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 Target;
        
    void Start()
    {
        Target = Random.insideUnitCircle * 4;
    }
        
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, 2 * Time.deltaTime);
        if (transform.position == Target)
            Target = Random.insideUnitCircle * 4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
