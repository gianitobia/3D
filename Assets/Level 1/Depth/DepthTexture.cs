using UnityEngine;

using System.Collections;

 

public class DepthTexture : MonoBehaviour {

    public Shader shader;

    public void Awake() {

        //transform.camera.depthTextureMode = DepthTextureMode.DepthNormals;

        //transform.camera.targetTexture.format = RenderTextureFormat.Depth;
		
        if (shader)

            transform.camera.SetReplacementShader(shader, null);

    }

}
