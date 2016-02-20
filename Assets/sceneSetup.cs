using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneSetup : MonoBehaviour {
    public GameObject bgm;
    public GameObject stageManager;
    public GameObject bgFx;
    public GameObject TSD;

    // Use this for initialization
    void Start()
    {
        GameObject BGfx = GameObject.Find("background_fx(Clone)");
        if (BGfx == null)
        {
            Instantiate(bgFx);
        }

        if (SceneManager.GetActiveScene().name != "TitleScene")
        {
            GameObject mainBgm = GameObject.Find("BgmMain(Clone)");
            if (mainBgm == null)
            {
                Instantiate(bgm);
            }
            GameObject cloneStageManager = GameObject.Find("StageManager(Clone)");
            if (cloneStageManager == null)
            {
                Instantiate(stageManager);
            }
            GameObject timeShotDeath = GameObject.Find("TimeShotDeath(Clone)");
            if (timeShotDeath == null)
            {
                Instantiate(TSD);
            }
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
