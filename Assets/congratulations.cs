using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class congratulations : MonoBehaviour
{

    private bool fallFlag = false;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (fallFlag == false)
        {

            if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("enemyBullet"))
            {
                GameObject mainBgm = GameObject.Find("BgmMain(Clone)");
                if (mainBgm != null)
                {
                    Destroy(mainBgm.gameObject);
                }
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);
                GetComponent<Rigidbody2D>().gravityScale = 1;
                fallFlag = true;
            }

        }

        if (other.gameObject.CompareTag("destroy"))
        {
            SceneManager.LoadScene("TitleScene");

            Destroy(this.gameObject);
        }

    }

}