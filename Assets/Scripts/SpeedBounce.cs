using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBounce : MonoBehaviour
{
    [SerializeField] private float _timeBounce = 2;
    [SerializeField] private float _bounceMultyplayer = 2;

    private void Start()
    {
        StartCoroutine(TimeLiveBounce());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.AddBounce(_bounceMultyplayer);
            TimeLiveBounce();
            player.DeleteBounce(_bounceMultyplayer);
        }
    }

    private IEnumerator TimeLiveBounce()
    {
        yield return new WaitForSeconds(_timeBounce);
    } 
}
