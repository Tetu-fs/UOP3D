using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class title : MonoBehaviour
{
    private GameObject bgmMain = null;

    private bool fallFlag = false;
    private Animator anima;
    
    // Use this for initialization
    void Start()
    {
        bgmMain = GameObject.Find("BgmMain(Clone)");
        GetComponent<Rigidbody2D>().gravityScale = 0;
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(bgmMain != null)
        {
            Destroy(bgmMain.gameObject);
        }

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