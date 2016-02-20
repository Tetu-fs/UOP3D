using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour
{

    public int shotSpeed = 3;
    // Use this for initialization
    public GameObject player;

    private Vector2 target;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            
            target = player.transform.position;
            Vector2 myPos = transform.position;
            Vector2 direction = target - myPos;
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * shotSpeed;
        }
        else if(player == null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * shotSpeed;
        }
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

    void gameClear()
    {

    }

    void OnBecameInvisible()
    {
       // Destroy(this.gameObject);
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
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy1") ||
            other.gameObject.CompareTag("Enemy2") || other.gameObject.CompareTag("Boss") ||
            other.gameObject.CompareTag("enemyBullet") || other.gameObject.CompareTag("bulletEmit")) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * shotSpeed;
        }

    }
}