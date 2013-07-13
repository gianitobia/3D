var lc : Camera;
var rc : Camera;

var dist = 0.03;
var drot = 0.5;
var rot = 1.0;
var minZoomFOV = 15.0;
var maxZoomFOV = 120.0;
var zoomSpeed = 20.0;
var distScroll = 0.03f;

	
function Start(){
	lc.aspect=lc.aspect*2;
	rc.aspect=rc.aspect*2;
	//lc.depthTextureMode = DepthTextureMode;
}

function Update () {
	
// aumento della disparità tra le telecamere
	if (Input.GetKey ("c")){ 
		if(dist<0.045){
			dist+=0.001;
			lc.transform.position=this.transform.TransformPoint (Vector3(-dist,0,0));
			rc.transform.position=this.transform.TransformPoint (Vector3(dist,0,0));
		}
		else {
			dist=0.05;
		}
		distScroll=dist;
		print (dist);


	}
// diminuzione della disparità tra le telecamere
    if (Input.GetKey ("x"))
    {
	    if(dist>0.005){
	    	dist-=0.001;
	    	lc.transform.position=this.transform.TransformPoint (Vector3(-dist,0,0));
			rc.transform.position=this.transform.TransformPoint (Vector3(dist,0,0));
		}
		else {
			dist=0;
		}
		distScroll=dist;
		print (dist);

   	}
// diminuzione angolo di convergenza
   	if (Input.GetKey ("v")){
   		if(rot<60){
   			rot=rot+drot;
		   	print(rot);

   			lc.transform.Rotate(Vector3(0,drot,0));
   			rc.transform.Rotate(Vector3(0,-drot,0));
   		}
   	}
//aumento angolo di convergenza
   	if (Input.GetKey ("b")){
   	print(rot);
   		if(rot>0){
   			rot=rot-drot;
   			lc.transform.Rotate(Vector3(0,-drot,0));
   			rc.transform.Rotate(Vector3(0,drot,0));
   		}
   	}
//zoom in
	if(Input.GetAxis("Mouse ScrollWheel") > 0 )
    {
        lc.fieldOfView -= zoomSpeed/8;
        rc.fieldOfView -= zoomSpeed/8;

	    if (lc.fieldOfView < minZoomFOV)
	    {
	        lc.fieldOfView = minZoomFOV;
	        rc.fieldOfView = minZoomFOV;
	    }
    }
//zoom out
    if(Input.GetAxis("Mouse ScrollWheel") < 0)
    {
            lc.fieldOfView += zoomSpeed/8;
            rc.fieldOfView += zoomSpeed/8;
	    if (lc.fieldOfView > maxZoomFOV)
	    {
	        lc.fieldOfView = maxZoomFOV;
	        rc.fieldOfView = maxZoomFOV;
	    }
    }
    
}

function OnGUI() {
    distScroll = GUI.HorizontalScrollbar(new Rect(25, 25, 100, 30), distScroll, 0.001f, 0.0F, 0.05F);
}