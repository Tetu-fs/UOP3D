using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;
    public GameObject ExprosionParticle;
    public GameObject canvas;
    public GameObject Line;
    public GameObject TimeShotDeath;

    public AudioSource shot;
    public AudioSource dead;

    public float speed = 8;

    public float minAngle = -30;
    public float maxAngle = 30;
    public float rotateSpeed = -1;
    public int playerLife = 2;

    public float Xscale = 0.5f;
    public float Yscale = 0.5f;
    public float Zscale = 0.5f;

    private bool onDamage = false;
    private bool clearFlag = false;
    private float clearTime = 0;
    private float deadMotion = 0;

    private GameClear gameClear;

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        Line = GameObject.Find("line");
        TimeShotDeath = GameObject.Find("TimeShotDeath(Clone)");
        if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "gameclear")
        {
            gameClear = canvas.GetComponent<GameClear>();

        }
    }

    void moveClamp()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, min.x, max.x);
        transform.position = playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        moveClamp();


        //操作
        if (playerLife > 0)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            worldMousePos.y = Line.transform.position.y;
            worldMousePos.z = 0;
            transform.position = worldMousePos;

            if (Input.GetMouseButtonDown(0))
            {
                shot.Play();
                if (clearFlag == false)
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "gameclear")
                    {
                        TimeShotDeath.SendMessage("ShotCounter");
                    }
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (clearFlag == false)
        {
            if (onDamage == false && !other.gameObject.CompareTag("Bullet"))
            {
                onDamage = true;
                playerLife -= 1;
                if (playerLife <= 0)
                {
                    if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "gameclear")
                    {
                        TimeShotDeath.SendMessage("DeathCounter");
                    }
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    transform.localScale = new Vector3(Xscale -= 0.25f, Yscale += 1.5f, Zscale);
                    dead.Play();

                    Instantiate(ExprosionParticle, transform.position, transform.rotation);
                }

            }
        }
    }

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "gameclear")
        {
            if (gameClear.clearCount > 0)
            {
                clearFlag = false;

                if (playerLife <= 0)
                {

                    deadMotion += 1 * Time.deltaTime;
                    transform.localScale = new Vector3(Xscale += 1f * Time.deltaTime, Yscale -= 2f * Time.deltaTime, Zscale -= 0.5f * Time.deltaTime);

                    if (deadMotion >= 1f)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            else if (gameClear.clearCount == 0)
            {
                clearFlag = true;
            }

        }
    }
}

