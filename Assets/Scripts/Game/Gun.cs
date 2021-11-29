using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Gun : MonoBehaviour
{
    [SerializeField] private List<Bullet> bullets = new List<Bullet>();
    [SerializeField] private float forceGun = 1;
    
    public UnityEvent gunShootEvent;

    public void Fire(Vector3 pointFire)
    {
        foreach (Bullet bullet in bullets)
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce((pointFire - transform.position).normalized * forceGun * bullet.gameObject.GetComponent<Bullet>().Force, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
            bullets.Add(collision.gameObject.GetComponent<Bullet>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
            bullets.Remove(collision.gameObject.GetComponent<Bullet>());
    }
}
