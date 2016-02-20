using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeShotDeath : MonoBehaviour {
    public Text TimeUp;
    public Text Shot;
    public Text Death;

    private float timeSet = 0;
    private int shotCount = 0;
    private int deathCount = 0;

    // Use this for initialization
    void Start()
    {
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
    void DeathCounter()
    {
        deathCount++;

        string DeathLabel = deathCount.ToString();
        Death.text = "Death -" + DeathLabel + "-";

    }
    // Update is called once per frame
    void Update() {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            Destroy(this.gameObject);
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
