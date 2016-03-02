using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeShotDeath : MonoBehaviour {
    public Text TimeUp;
    public Text Shot;
    public Text Death;
    public Text degree;

    private float timeSet = 0;
    private int shotCount = 0;
    private int deathCount = 0;
    private int yellowShot = 0;

    private string FastNoDeath = "凄腕プレイヤー";
    private string FastClear = "早撃ちマック";
    private string deathUnder10 = "ベテラン";
    private string GreatPlayer = "UOPマスター";

    private string shot10 = "ミニマリスト";
    private string shot500 = "トリガーハッピー";
    private string Death100 = "死にたがり";
    private string yellowShooter = "黄色が嫌い？";

    // Use this for initialization
    void Start()
    {
        TimeUp.gameObject.SetActive(false);
        Shot.gameObject.SetActive(false);
        Death.gameObject.SetActive(false);
        degree.gameObject.SetActive(false);
        degree.material.color = Color.white;

       timeSet = 0;
        shotCount = 0;
        deathCount = 0;

        if (SceneManager.GetActiveScene().name != "TitleScene")
        {
            DontDestroyOnLoad(this);
        }
    }

    void ShotCounter()
    {
        shotCount++;

        string shotLabel = shotCount.ToString();
        Shot.text = "Shot -" + shotLabel + "-";

    }

    void yellowCounter()
    {
        yellowShot++;
    }
    void DeathCounter()
    {
        deathCount++;

        string DeathLabel = deathCount.ToString();
        Death.text = "Death -" + DeathLabel + "-";

    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene().name == "gameclear")
        {
            TimeUp.gameObject.SetActive(true);
            Shot.gameObject.SetActive(true);
            Death.gameObject.SetActive(true);

            if (yellowShot >= 200)
            {
                degree.text = yellowShooter;
                degree.material.color = Color.yellow;
            }
            else if (shotCount <= 10)
            {
                if ((int)timeSet <= 120)
                {
                    degree.text = "マジで？ズルしてない？ホントに？";
                }
                else
                {
                    degree.text = shot10;
                }
            }
            else
            {
                if ((int)timeSet <= 120)
                {
                    if (deathCount == 0)
                    {
                        if (shotCount <= 75)
                        {
                            degree.text = GreatPlayer;
                        }
                        else
                        {
                            degree.text = FastNoDeath;
                        }
                    }
                    else if (deathCount > 100)
                    {
                        degree.text = Death100;
                    }

                    else if (shotCount >= 500)
                    {
                        degree.text = shot500;
                    }

                }
                else
                {
                    if (deathCount < 10)
                    {
                        degree.text = deathUnder10;
                    }
                    else if (deathCount > 100)
                    {
                        degree.text = Death100;
                    }
                    else if (shotCount >= 500)
                    {
                        degree.text = shot500;
                    }
                }
            }
            degree.gameObject.SetActive(true);

        }
        else
        {
            TimeUp.gameObject.SetActive(false);
            Shot.gameObject.SetActive(false);
            Death.gameObject.SetActive(false);
        }
       
    }

    void FixedUpdate()
    {
       string TimeLabel = ((int)timeSet).ToString();

        if (SceneManager.GetActiveScene().name != "TitleScene" && SceneManager.GetActiveScene().name != "gameclear")
        {
            timeSet += 1 * Time.deltaTime;

            TimeUp.text = "Time -" + TimeLabel + "-";
        }

    }
}
