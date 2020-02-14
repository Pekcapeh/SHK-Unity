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
        _player.EnemyDestroyed += OnEnemyDestroу;
    }

    private void OnDisable()
    {
        _player.EnemyDestroyed -= OnEnemyDestroу;
    }

    private void Start()
    {
        _enemies = new List<Enemy>(_enemyContainer.GetComponentsInChildren<Enemy>());
    }

    private void OnEnemyDestroу(Enemy enemy)
    {
        _enemies.Remove(enemy);
        CheckEnemy();
    }
       
    private void CheckEnemy()
    {
        if (_enemies.Count == 0)
        {
            _endScreen.Show();
        }
    }
}
