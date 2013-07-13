
var target : Transform;
var look = false;

function Update () {

	var rcw = GameObject.Find("Right Camera");
			
	print(rcw.transform.localEulerAngles.y);
	print(this.GetComponent(CameraDisparity).rot);
	
	if(Input.GetKeyDown("l")){
		look=!look;
		if(look) 
		{
			print(String.Format("Look at {0}",target.name)); 
			//transform.LookAt(target);
		}
		else
		{
			print(String.Format("Stop looking at {0}",target.name));
		}
	}
	if(look) 
		{
		transform.LookAt(target);
		//da scomm
		//var distance = Vector3.Distance(transform.position, target.position);
		//var eyedist = this.GetComponent(CameraDisparity).dist;
		
		
		//var diag = Mathf.Sqrt(distance*distance + eyedist*eyedist);
		//print("diag");
		//print(diag);
		//print("eyedist");
		//print(eyedist);
		
		//da scomm
		//var theta = Mathf.Atan(distance/eyedist);
		
		
		//print("theta");
		//print(theta);
			
		//da scomm	
		//var lc = GameObject.Find("Left Camera");
		//var rc = GameObject.Find("Right Camera");
			
		//print(rc.transform.localEulerAngles.y);
		
		//da scomm
		//var rotation=theta-rc.transform.localEulerAngles.y;
			
		//da scomm
		//lc.transform.Rotate(Vector3(0,-rotation,0));
 		//rc.transform.Rotate(Vector3(0,rotation,0));
 		
		//
		//print(this.GetComponent(CameraDisparity).rot);
		//print(theta);
	
	}
	
}