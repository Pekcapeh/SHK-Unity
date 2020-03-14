using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private EndScreen _endScreen;
    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _player.EnemyDestroyed += OnEnemyDestroуed;
    }

    private void OnDisable()
    {
        _player.EnemyDestroyed -= OnEnemyDestroуed;
    }

    private void Start()
    {
        _enemies = new List<Enemy>(_enemyContainer.GetComponentsInChildren<Enemy>());
    }

    private void OnEnemyDestroуed(Enemy enemy)
    {
        _enemies.Remove(enemy);
        CheckCountEnemy();
    }
       
    private void CheckCountEnemy()
    {
        if (_enemies.Count == 0)
        {
            _endScreen.Show();
        }
    }
}
