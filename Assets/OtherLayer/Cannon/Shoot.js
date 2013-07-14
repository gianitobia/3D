
var proiettile : Rigidbody;
var objPos : GameObject;


function Update () {
 	if (Input.GetKeyDown("f")) {
		var palla : Rigidbody;
		palla = Instantiate(proiettile, objPos.transform.position, Quaternion.identity);
        //palla.velocity = transform.TransformDirection (Vector3.right * 70);
    }
}