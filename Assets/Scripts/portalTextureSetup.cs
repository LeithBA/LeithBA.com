using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTextureSetup : MonoBehaviour
{

    public Camera[] cameras;
    public Material[] cameraMaterials;
    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].targetTexture != null)
            {
                cameras[i].targetTexture.Release();
            }
            cameras[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMaterials[i].mainTexture = cameras[i].targetTexture;
        }

    }
}
