﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Desert()
    {
        SceneManager.LoadScene(1);
    }

    public void Castle()
    {
        SceneManager.LoadScene(2);
    }
}
