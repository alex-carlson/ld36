﻿using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1.5f);
	}
}
