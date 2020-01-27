using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    private float _time  = 0;
    private float _startSpeed;

    public event UnityAction<Enemy> EnemyDestroyed;

    private void Start()
    {
        _startSpeed = _speed;
    }

    private void Update()
    {
        CheckTimer();

        float moveHorizontal = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        transform.Translate(moveHorizontal, moveVertical, 0);
    }

    private void AddBounce(float bounсeMultiplayer, float bounсeTime)
    {        
        if (_time == 0)
            _speed *= bounсeMultiplayer;
        
        _time += bounсeTime;
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
        _speed = _startSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            EnemyDestroyed?.Invoke(enemy);
            Destroy(enemy.gameObject);
        }
    }
}
