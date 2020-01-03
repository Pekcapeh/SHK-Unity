using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D _rigidbody2D;
    
    void Update()
    {
        GameObject[] result = GameObject.FindGameObjectsWithTag("Enemy");

        if(result.Length == 0)
        {            
            enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, Speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -Speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Speed * Time.deltaTime, 0, 0);
    }

    public void EatBox()
    {
        
        {

        }
    }
}
