#pragma strict

function Start () {

}

function Update () {
	if(Input.GetKeyUp(KeyCode.Escape))
    {
        Application.LoadLevel("main_menu");
        Debug.Log("Abbandonata scena");
    }
 
}