using UnityEngine;
using System.Collections;

public class callStageManager : MonoBehaviour {

    public GameObject stageManager;
	// Use this for initialization
	void Start () {
        if (stageManager == null)
        {
            stageManager = GameObject.Find("StageManager(Clone)");
        }
    }

    public void OnClick()
    {
        stageManager.SendMessage("nextStage");
    }
    // Update is called once per frame
    void Update () {

    }
}
