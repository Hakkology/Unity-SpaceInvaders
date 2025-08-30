using UnityEngine;

public class MysteryShip : Invader
{
    public float speed = 5.0f;
    public float attackRate = 2.0f; // Mermi atış hızı
    private Vector3 _direction;
    private Vector3 _rightEdge;
    private Vector3 _leftEdge;
    private bool _isActive = false;

    void Start()
    {
        _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // MysteryShip hareketini ve saldırı mekanizmasını başlat
        InvokeRepeating(nameof(SpawnMysteryShip), 2f, 8.0f);
    }

    void Update()
    {
        if (_isActive)
        {
            transform.position += _direction * speed * Time.deltaTime;


            if (transform.position.x < _leftEdge.x || transform.position.x > _rightEdge.x)
            {
                _isActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void SpawnMysteryShip()
    {
        // Yönü rastgele belirle: soldan sağa veya sağdan sola
        if (Random.value > 0.5f)
        {
            transform.position = new Vector3(_leftEdge.x, 12, 0); // Sol kenardan başla
            _direction = Vector3.right;
        }
        else
        {
            transform.position = new Vector3(_rightEdge.x, 12, 0); // Sağ kenardan başla
            _direction = Vector3.left;
        }

        _isActive = true;
        gameObject.SetActive(true);

        // Mermi atışı başlat
        InvokeRepeating(nameof(FireSpecialMissile), attackRate, attackRate);
    }

    private void FireSpecialMissile()
    {
        if (_isActive)
        {
            Projectile missile = SpecialMissilePool.Instance.GetFromPool();
            if (missile != null)
            {
                missile.transform.position = this.transform.position;
                missile.direction = Vector3.down; // Mermi yönü aşağı
                missile.gameObject.SetActive(true);
            }
        }
    }

    void OnDisable()
    {
        CancelInvoke(nameof(FireSpecialMissile));
    }
}
