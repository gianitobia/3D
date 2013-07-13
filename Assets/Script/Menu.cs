using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
 
public class Menu : MonoBehaviour {
	
	//Import per il wii mote
	[DllImport ("UniWii")]
	private static extern void wiimote_start();
 
	[DllImport ("UniWii")]
	private static extern void wiimote_stop();
 
	[DllImport ("UniWii")]
	private static extern int wiimote_count();
	
 	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonUp(int which);
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonLeft(int which);
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonRight(int which);
	[DllImport ("UniWii")]
	private static extern bool wiimote_getButtonDown(int which);
	
	//Fine import per wiimote
	
	private String display;
	//definizioni per i bottoni
	public int selGridInt = 0;    //This integer is the index of the button we are hovering above or have selected
	public int selGridInt2 = 0;    //This integer is the index of the button we are hovering above or have selected
	 
	string[] selStrings =  new string[] {"Scena normale", "Scena riflettente", "Scena buia", "Scena in movimento"};
	string[] sceneName =  new string[] {"Level 1","Level 2","Level 3","Level 4"};
	 
	private int maxButton;    // The total number of buttons in our grid
	 
	private bool leftPressed = false;
	private bool rightPressed = false;
	
	void Start()
	{
        wiimote_start();
	    maxButton = selStrings.Length;    // Set the total no. of buttons to our String array size
	}
	 
	void Update()
	{
		
		int c = wiimote_count();
		if (c>0) {
			for (int i=0; i<=c-1; i++) 
			{
				if(wiimote_getButtonRight(i)){
					if(!rightPressed)
					{
						rightPressed = true;
						// Here we want to create a wrap around effect by resetting the selGridInt if it exceeds the no. of buttons
				        if(selGridInt < (maxButton-1))
				        {
				            selGridInt++;
				            selGridInt2++;
				        }
				        else
				        {
				            selGridInt = 0;
				            selGridInt2 = 0;
				        }
					}
					
				}
				else
				{
					if(rightPressed)
						rightPressed=false;
				}
				
				if(wiimote_getButtonLeft(i))
				{
					// Here we want to create a wrap around effect by resetting the selGridInt if it exceeds the no. of buttons
			        if(!leftPressed)
					{
						leftPressed = true;
						if(selGridInt > 0)
				        {
				            selGridInt--;
				            selGridInt2--;
				        }
				        else
				        {
				            selGridInt = maxButton - 1;
				            selGridInt2 = maxButton - 1;
				        }
					}
				}
				else
				{
					if(leftPressed)
						leftPressed=false;
					
				}
			}
		}
	    // Get keyboard input and increase or decrease our grid integer
	    if(Input.GetKeyUp(KeyCode.LeftArrow))
	    {
	        // Here we want to create a wrap around effect by resetting the selGridInt if it exceeds the no. of buttons
	        if(selGridInt > 0)
	        {
	            selGridInt--;
	            selGridInt2--;
	        }
	        else
	        {
	            selGridInt = maxButton - 1;
	            selGridInt2 = maxButton - 1;
	        }
	    }
	 
	    if(Input.GetKeyUp(KeyCode.RightArrow))
	    {
	        // Create the same wrap around effect as above but alter for down arrow
	        if(selGridInt < (maxButton-1))
	        {
	            selGridInt++;
	            selGridInt2++;
	        }
	        else
	        {
	            selGridInt = 0;
	            selGridInt2 = 0;
	        }
	    }
	 
	    if(Input.GetKeyUp(KeyCode.Return))
	    {
	        switch(selGridInt)
	        {
	            case 0: Debug.Log("Button "+(selGridInt + 1 )+ " pressed.");
	                break;
	            case 1: Debug.Log("Button "+(selGridInt + 1 )+" pressed.");
	                break;
	            case 2: Debug.Log("Button "+(selGridInt + 1 )+ " pressed.");
	                break;
	            case 3: Debug.Log("Button "+(selGridInt + 1 )+ " pressed.");
	                break;
	        }
	        Application.LoadLevel(sceneName[selGridInt]);
	    }
	}
	 
	void OnGUI () 
	{
		int c = wiimote_count();
		if (c>0) {
			display = "";
			for (int i=0; i<=c-1; i++) {
				display += "Wiimote collegato!\n";
			}
		}
		else{
			display = "Premere i tasti '1' e '2' sul Wii Remote.";
		}
		
		GUI.Label( new Rect(Screen.width/9,Screen.height*3/4+40, Screen.width/4, 100), display);
		GUI.Label( new Rect(Screen.width/2+Screen.width/9,Screen.height*3/4+40, Screen.width/4, 100), display);
		
	    selGridInt = GUI.SelectionGrid(new Rect(Screen.width/8-10, Screen.height/4, Screen.width/4, Screen.height/2),selGridInt,selStrings,2);
	    selGridInt2 = GUI.SelectionGrid(new Rect(5*Screen.width/8+10, Screen.height/4, Screen.width/4, Screen.height/2),selGridInt2,selStrings,2);
	} 

    void OnApplicationQuit() {

        wiimote_stop();

    } 
}