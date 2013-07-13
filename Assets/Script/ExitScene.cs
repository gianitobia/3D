using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class ExitScene : MonoBehaviour {	
	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonHome(int which);
	
	private bool homePressed = false;
	
	// Update is called once per frame
	void Update () {
		int c = wiimote_count();
		if (c>0) {
			for (int i=0; i<=c-1; i++) 
			{
				if(wiimote_getButtonHome(i)){
					if(!homePressed)
					{
						homePressed = true;
						Application.LoadLevel("main_menu");
	       				Debug.Log("Abbandonata scena");
					}
					
				}
				else
				{
					if(homePressed)
						homePressed=false;
				}
			}
		}
		
		if(Input.GetKeyUp(KeyCode.Escape))
	    {
	        Application.LoadLevel("main_menu");
	        Debug.Log("Abbandonata scena");
	    }
	}
}
