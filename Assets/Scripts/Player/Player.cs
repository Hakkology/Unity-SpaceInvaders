using UnityEngine;

public class Player : MonoBehaviour 
{
    public float speed = 5.0f;
    public Vector3 projectileDirection = Vector3.up; // Mermi yönü
    public InvaderGrid invaderGrid;

    void Update() 
    {
        // Hareket kontrolü
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        // Ateş etme kontrolü
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Havuzdan mermi alıyoruz
        Projectile laser = LaserPool.Instance.GetFromPool();
        if (laser != null)
        {
            laser.transform.position = this.transform.position; // Mermiyi oyuncunun pozisyonuna ayarlıyoruz
            laser.direction = projectileDirection; // Merminin yönünü ayarlıyoruz
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") ||
            other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            if (invaderGrid != null)
            {
                GameState.Instance.TakeDamage(1);
                invaderGrid.RestartGame();
            }
        }
    }
}
