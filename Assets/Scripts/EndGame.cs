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
        _player.EnemyDestroyed += OnEnemyDestroyer;
    }

    private void OnDisable()
    {
        _player.EnemyDestroyed -= OnEnemyDestroyer;
    }

    private void Start()
    {
        _enemies = new List<Enemy>(_enemyContainer.GetComponentsInChildren<Enemy>());
    }

    private void OnEnemyDestroyer(Enemy enemy)
    {
        _enemies.Remove(enemy);
        SearchEnemy();
    }
       
    private void SearchEnemy()
    {
        if (_enemies.Count == 0)
        {
            _endScreen.Show();
        }
    }
}
