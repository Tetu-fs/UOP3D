using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameClear : MonoBehaviour
{

    public GameObject clearLabel;
    public GameObject gameOverLabel;
    public GameObject RetryLabel;
    public GameObject NextLabel;
    public GameObject enemyBullet;

    public Text countLabel;
    public int clearCount = 3;
    private float clearTime = 0;

    private string titleScene = "TitleScene";
    private string clearScene = "gameclear";
    private bool bossFlag = false;

    // Use this for initialization
    void Start()
    {

        GameObject boss = GameObject.Find("Boss");
        if (boss != null)
        {
            bossFlag = true;
        }
        else
        {
            bossFlag = false;
        }

        countLabel.enabled = false;
        clearLabel.SetActive(false);
        RetryLabel.SetActive(false);
        NextLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length +
                         GameObject.FindGameObjectsWithTag("Enemy1").Length +
                         GameObject.FindGameObjectsWithTag("Enemy2").Length;
        int bossCount = GameObject.FindGameObjectsWithTag("Boss").Length;
        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        string count = clearCount.ToString();

        if (SceneManager.GetActiveScene().name != titleScene  && SceneManager.GetActiveScene().name != clearScene)
        {
            //GameOver
            if (playerCount <= 0)
            {
                countLabel.enabled = false;
                gameOverLabel.SetActive(true);
                RetryLabel.SetActive(true);
                clearLabel.SetActive(false);
                NextLabel.SetActive(false);

            }

            //Clear CountDown
            else if (bossFlag == false)
            {
                if (enemyCount <= 0)
                {
                    countLabel.enabled = true;
                    clearTime += 1 * Time.deltaTime;
                    countLabel.text = "- " + count + " -";

                    if (clearTime >= 1 && clearCount > 0)
                    {
                        clearCount--;
                        clearTime = 0;
                    }
                    //Clear
                    if (clearCount == 0)
                    {
                        countLabel.enabled = false;
                        clearLabel.SetActive(true);
                        RetryLabel.SetActive(true);
                        NextLabel.SetActive(true);
                    }
                }
            }
            else
            {
                if (bossCount <= 0)
                {
                    countLabel.enabled = true;
                    clearTime += 1 * Time.deltaTime;
                    countLabel.text = "- " + count + " -";

                    if (clearTime >= 1 && clearCount > 0)
                    {
                        clearCount--;
                        clearTime = 0;
                    }
                    //Clear
                    if (clearCount == 0)
                    {
                        countLabel.enabled = false;
                        clearLabel.SetActive(true);
                        RetryLabel.SetActive(true);
                        NextLabel.SetActive(true);
                    }
                }
            }
        }
    }
}
