using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using InControl;

public class LevelManager : MonoBehaviour {

    public static int score = 0;
    public static int hoops = 0;
	public static int redHoops = 0;
	public static int blueHoops = 0;

	bool rtn;

	void Update(){

		var inputDevice = (InputManager.Devices.Count > 0) ? InputManager.Devices[0] : null;

		if (inputDevice == null) {
			rtn = Input.GetKeyDown (KeyCode.Escape);
		} else {
			rtn = inputDevice.Action2.WasPressed;
		}

		if(rtn){
			SceneManager.LoadScene (0);
		}
	}
}
