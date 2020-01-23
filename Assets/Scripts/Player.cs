using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    private float _speed = 4;
    private float _time  = 0;
    private bool _timer = false;
    private float _moveHorizontal;
    private float _moveVertical;


    private void Update()
    {
        Timer();

        _moveHorizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _moveVertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.Translate(_moveHorizontal, _moveVertical, 0);

        SearchEnemy();
    }

    private void SearchEnemy()
    {
        if (!FindObjectOfType<Enemy>())
        {
            _endScreen.GetComponent<EndScreen>().End();
        }
    }

    private void AddBounce()
    {
        _time += 2;

        if (_timer == false)
            _speed *= 2;

        _timer = true;
    }

    private void Timer()
    {        
        if (_time > 0)
        _time -= Time.deltaTime;

        if (_time < 0)
            DeleteBounce();
    }

    private void DeleteBounce()
    {
        _time = 0;
        _speed /= 2;
        _timer = false;
    }
}
