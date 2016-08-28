using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using InControl;

public class LevelManager : MonoBehaviour {

    public static int score = 0;
    public static int hoops = 0;
	public static int redHoops = 0;
	public static int blueHoops = 0;

	void Update(){

		var inputDevice = (InputManager.Devices.Count > 0) ? InputManager.Devices[0] : null;

		if(inputDevice.Action2){
			SceneManager.LoadScene (0);
		}
	}
}
