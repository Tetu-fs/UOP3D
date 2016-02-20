using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {
    private int stageNum = 1;
    private const int MAXSTAGE = 10;
    public GameObject self;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }
    void nextStage()
    {
        if (stageNum < MAXSTAGE)
        {
            stageNum += 1;
            SceneManager.LoadScene("renshu" + stageNum);
        }
        else
        {
            SceneManager.LoadScene("gameclear");
            stageNum = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
