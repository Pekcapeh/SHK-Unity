using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBounce : MonoBehaviour
{
    [SerializeField] private float _timeBounce = 2;
    [SerializeField] private float _bounceMultyplayer = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StartCoroutine(TimeLiveBounce(player));
            TimeLiveBounce(player);
        }
    }

    private IEnumerator TimeLiveBounce(Player player)
    {
        player.AddBounce(_bounceMultyplayer);
        RemoveBounce();
        yield return new WaitForSeconds(_timeBounce);
        player.DeleteBounce(_bounceMultyplayer);
        Destroy(gameObject);
    } 

    private void RemoveBounce()
    {
        transform.Translate(1000, 1000, 0);
    }
}
