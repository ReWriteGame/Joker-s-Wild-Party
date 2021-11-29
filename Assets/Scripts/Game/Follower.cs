using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Follower : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    private Gun gun;
    private Camera cam;

    private bool isTouch = false;

    public UnityEvent fireEvent;

    void Start()
    {
        cam = Camera.main;
        gun = GetComponent<Gun>();
    }


    [SerializeField] private Vector3 pos;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                pos = cam.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
            }
        }
    }

    public void Fire()
    {
        gun.Fire(pos);
        fireEvent?.Invoke();
    }
    
}
