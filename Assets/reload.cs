using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    public void OnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
