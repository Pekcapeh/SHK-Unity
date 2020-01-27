using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 4;

    public event UnityAction<Enemy> EnemyDestroyed;

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);       
        move *= _speed * Time.deltaTime;
        transform.Translate(move);
    }

    public void AddBounce(float bounсeMultiplayer)
    {        
        _speed *= bounсeMultiplayer;
    }    

    public void DeleteBounce(float bounсeMultiplayer)
    {
        _speed /= bounсeMultiplayer;
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
