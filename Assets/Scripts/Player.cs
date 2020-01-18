using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float _speed = 4;    
    
    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, Input.GetAxis("Vertical") * _speed * Time.deltaTime, 0);
    }   
}
