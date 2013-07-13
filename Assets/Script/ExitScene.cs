using UnityEngine;
using System.Collections;

public class ExitScene : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
	    {
	        Application.LoadLevel("main_menu");
	        Debug.Log("Abbandonata scena");
	    }
	}
}
