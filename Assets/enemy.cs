using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{

    public GameObject enemyBullet;
    public GameObject exprosion;

    public AudioSource hit;

    private Vector2 rolling = new Vector2(60,60);
    private Vector2 rolling2 = new Vector2(60, 0);

    private bool fallFlag = false;
    private bool flip = true;
    private float moveX = 0;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        moveX += transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 enemyPosition = transform.position;
        enemyPosition.x = Mathf.Clamp(enemyPosition.x, min.x, max.x);
        enemyPosition.y = transform.position.y;
        transform.position = enemyPosition;
        if (!this.gameObject.CompareTag("Enemy1"))
        {
            transform.Rotate(rolling * Time.deltaTime);
        }
        else
        {
            transform.Rotate(rolling2 * Time.deltaTime);
        }
        if (fallFlag == false)
        {
            if (this.gameObject.CompareTag("Enemy2"))
            {
                if (moveX > max.x)
                {
                    flip = false;
                }
                else if (moveX < min.x)
                {
                    flip = true;
                }
                if (flip == true)
                {
                    transform.position = new Vector2(moveX += 5 * Time.deltaTime, transform.position.y);
                }
                else
                {
                    transform.position = new Vector2(moveX -= 5 * Time.deltaTime, transform.position.y);
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (fallFlag == false)
        {

            if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("enemyBullet"))
            {
                hit.Play();

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);
                GetComponent<Rigidbody2D>().gravityScale = 1;
                fallFlag = true;
            }

        }

        if (other.gameObject.CompareTag("destroy") || other.gameObject.CompareTag("Boss"))
        {
            if (!this.gameObject.CompareTag("Enemy4"))
            {
                Instantiate(enemyBullet, transform.position, transform.rotation);
            }
            Instantiate(exprosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }

}