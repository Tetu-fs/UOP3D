using UnityEngine;
using System.Collections;

public class bossBullet : MonoBehaviour {

    public float shotSpeed = 3f;
    public GameObject player;

    private Vector2 target;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(0f, 2f)) * shotSpeed;

    }
    void boundBullet()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 bulletPosition = transform.position;
        bulletPosition.x = Mathf.Clamp(bulletPosition.x, min.x, max.x);
        bulletPosition.y = Mathf.Clamp(bulletPosition.y, min.y, max.y);

        transform.position = bulletPosition;


        Vector2 eBlulletVec = GetComponent<Rigidbody2D>().velocity;

        if (bulletPosition.x <= min.x || bulletPosition.x >= max.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(eBlulletVec.x * -1, eBlulletVec.y);
        }
        if (bulletPosition.y <= min.y || bulletPosition.y >= max.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(eBlulletVec.x, eBlulletVec.y * -1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        boundBullet();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("bulletEmit"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * shotSpeed;
        }

    }
}
