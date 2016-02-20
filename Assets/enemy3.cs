using UnityEngine;
using System.Collections;

public class enemy3 : MonoBehaviour
{
    private int BossLife = 5;
    public GameObject Beam;
    public GameObject charge;
    public AudioSource bossDamage;
    public AudioSource bossBeam;
    public GameObject bossBullet;
    public GameObject exprosion;

    private bool fallFlag = false;
    private bool onDamage = false;
    private float waitTime = 0;
    private float shakeTime = 0;

    private float animTime = 0;

    private bool flip = true;
    private Vector2 nowPosition;
    private float moveX = 0;

    private float speed = 3;

    // Use this for initialization
    void Start()
    {
        moveX += transform.position.x;

    }

    // Update is called once per frame
    public void beamcharge(int chargeing)
    {

        if (chargeing == 1) { 
        GameObject beamCharge = (GameObject)Instantiate(charge, transform.position, charge.transform.rotation);
        beamCharge.transform.parent = transform;
        }
        else
        {
            GameObject beam_charge = GameObject.Find("beam_charge(Clone)");
            Destroy(beam_charge.gameObject);
        }
    }

    public void beamShot(int shot)
    {
        if (shot == 1)
        {
            bossBeam.Play();

            Instantiate(Beam, transform.position, Beam.transform.rotation);
        }
        else
        {
            GameObject beamCopy = GameObject.Find("beam(Clone)");
            if (beamCopy != null)
            {
                Destroy(beamCopy.gameObject);
            }
        }
    }

    void Update()
    {

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 enemyPosition = transform.position;
        enemyPosition.x = Mathf.Clamp(enemyPosition.x, min.x, max.x);
        transform.position = enemyPosition;

        if (fallFlag == false && onDamage == false)
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
                transform.position = new Vector2(moveX  += speed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(moveX -= speed * Time.deltaTime, transform.position.y);
            }
            nowPosition = transform.position;
        }
        else if (fallFlag == false && onDamage == true)
        {
            shakeTime += 1 * Time.deltaTime;
            if (shakeTime <= 1)
            {
                transform.position = new Vector2(transform.position.x, nowPosition.y + (Mathf.Sin(Time.frameCount) / 10)); 
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
                shakeTime = 0;

                onDamage = false;
            }
        }
    }
    void FixedUpdate()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (fallFlag == false)
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enemy2") || other.gameObject.CompareTag("Enemy4"))
            {
                onDamage = true;
                BossLife -= 1;
                speed ++;
                bossDamage.Play();
                if (BossLife == 0)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4);
                    GetComponent<Rigidbody2D>().gravityScale = 1;
                    fallFlag = true;
                }
            }
        }
        if (other.gameObject.CompareTag("destroy"))
        {
 
            for (int i = 0; i <= 30; i++)
            {
                Instantiate(bossBullet, transform.position, transform.rotation);
            }
            Instantiate(exprosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
