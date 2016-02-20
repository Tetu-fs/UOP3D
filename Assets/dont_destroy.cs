using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dont_destroy : MonoBehaviour {

    public bool destroy = true;
    // Use this for initialization
    void Start()
    {
        if (destroy == true&& SceneManager.GetActiveScene().name != "TitleScene")
        {
            DontDestroyOnLoad(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
