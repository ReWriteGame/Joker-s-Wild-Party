using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force = 0;

    public float Force { get => force; private set => force = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pumpkin>() || collision.gameObject.GetComponent<Destroyer>())
            gameObject.GetComponent<Destroyable>().Destroy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Destroyer>())
            gameObject.GetComponent<Destroyable>().Destroy();
    }

}
