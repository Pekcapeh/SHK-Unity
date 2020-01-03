using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public bool Timer;
    public float TimeBalence;
    
    void Update()
    {
        if (Timer)
        {
            TimeBalence -= Time.deltaTime;

            if(TimeBalence < 0)
            {
                Timer = false;
                Speed /= 2;
            }
        }

        GameObject[] result = GameObject.FindGameObjectsWithTag("Enemy");

        if(result.Length == 0)
        {            
            enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, Speed * UnityEngine.Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -Speed * UnityEngine.Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-Speed * UnityEngine.Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Speed * UnityEngine.Time.deltaTime, 0, 0);
    }

    public void SendMessage()
    {
        if (b.name == "Enemy")
        {
            Destroy(b);
        }

        if (b.name == "Speed")
        {
            Speed *= 2;
            Timer = true;
            TimeBalence = 2;
        }
    }
}
