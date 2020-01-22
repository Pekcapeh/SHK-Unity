using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float _speed = 4;
    private float _moveHorizontal;
    private float _moveVertical;

    private void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _moveVertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.Translate(_moveHorizontal, _moveVertical, 0);
    }   
}
