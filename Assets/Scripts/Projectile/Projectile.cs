using UnityEngine;
using System;

public class Projectile : MonoBehaviour 
{
    public Action<Projectile> OnDestroyed; // Action tanımlama

    public Vector3 direction;
    public float speed;

    void Update() 
    {
        transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Bunker bunker = other.GetComponent<Bunker>();
        if (bunker == null || bunker.CheckCollision(this.GetComponent<BoxCollider2D>(), transform.position))
        {
            OnDestroyed?.Invoke(this); 
        }
    }
}
