using UnityEngine;
using System.Collections;

public class bulletEmit : MonoBehaviour {

    public GameObject enemyBullet;
    public AudioSource hit;

    private Animator hitanima;
    private bool hitMove = false; 
    private Vector2 rolling = new Vector2(0, 120);
    private Vector2 nowPosition;
    private float shakeTime = 0;
    // Use this for initialization
    void Start () {
        nowPosition = transform.position;
        hitanima = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        nowPosition = transform.position;

        transform.Rotate(rolling * Time.deltaTime);
        if (hitMove == true)
        {
            shakeTime += 1 * Time.deltaTime;
        }
        if(shakeTime >= 0.5f)
        {
            hitMove = false;
            hitanima.SetBool("hit", false);
            shakeTime = 0;
        }
    }

    void animastop(int check)
    {
        if (check > 0)
        {
            hitanima.SetBool("hit", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if(hitMove == false) { 
            hitanima.SetBool("hit", true);
            hitMove = true;
            }
            hit.Play();
            Instantiate(enemyBullet, transform.position, transform.rotation);
        }
    }
}
