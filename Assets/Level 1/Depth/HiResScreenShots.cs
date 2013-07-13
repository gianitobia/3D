using UnityEngine;
using System.Collections;
 
public class HiResScreenShots : MonoBehaviour {
    public int resWidth = Screen.width; 
    public int resHeight = Screen.height;
 	public static string folder="screenshots";
	private static string realFolder;
    public bool takeHiResShot = false;
 
    public static string ScreenShotName(int width, int height) {
        return string.Format("{3}/screen_{0}x{1}_{2:D04}.png", width, height,Time.frameCount, realFolder);
    }
 
    public void TakeHiResShot() {
        takeHiResShot = !takeHiResShot;
		//Debug.Log("su carta...");
		int count = 1;
		if(takeHiResShot){
			realFolder=folder;
    		while (System.IO.Directory.Exists(realFolder)) {
        		realFolder = folder + count;
        		count++;
    		}
			System.IO.Directory.CreateDirectory(realFolder);
		}
		
    }
 
	void LateUpdate(){
        if(Input.GetKeyDown("k")){Debug.Log("Recording k"); TakeHiResShot();}
		//Debug.Log(takeHiResShot);
		if (takeHiResShot) {
			Recording();
		}
	}
	
	
	
    //IEnumerable Recording() {
	void Recording() {
			//Debug.Log("1");
			//yield return new WaitForEndOfFrame();
        	//Debug.Log("2");
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            //camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
			
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));

    }
}
