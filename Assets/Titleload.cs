﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Titleload : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void OnClick()
    {
        SceneManager.LoadScene("TitleScene");
    }
    // Update is called once per frame
    void Update () {
	
	}
}