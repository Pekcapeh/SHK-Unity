using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    private float _speed = 4;
    private float _time  = 0;
    private float _moveHorizontal;
    private float _moveVertical;
    
    private void Update()
    {
        CheckTimer();

        _moveHorizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _moveVertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.Translate(_moveHorizontal, _moveVertical, 0);
    }

    private void SearchEnemy()
    {
        if (FindObjectsOfType<Enemy>().Length == 0 )
        {
            _endScreen.GetComponent<EndScreen>().ShowEnd();
        }
    }

    private void AddBounce()
    {        
        if (_time == 0)
            _speed *= 2;
        
        _time += 2;
    }

    private void CheckTimer()
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
        }

        SearchEnemy();
    }
}
