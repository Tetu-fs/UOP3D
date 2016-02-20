using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class title : MonoBehaviour
{

    private bool fallFlag = false;
    private Animator anima;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void gameStart(int check)
    {
        if(check != 0)
        {
            SceneManager.LoadScene("renshu1");

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (fallFlag == false)
        {

            if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("enemyBullet"))
            {
                anima.SetBool("hit", true);

                fallFlag = true;
            }

        }
    }

}