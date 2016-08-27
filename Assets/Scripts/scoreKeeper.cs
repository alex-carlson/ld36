using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreKeeper : MonoBehaviour {

    Text myText;

    void Start()
    {
        myText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        myText.text = "Hoops: "+LevelManager.hoops;
    }
}
