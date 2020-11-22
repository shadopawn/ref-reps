using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class KinectVideoScript : MonoBehaviour
{
    Texture2D displayTexture;

    MeshRenderer meshRen;

    // Start is called before the first frame update
    void Start()
    {
        meshRen = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Texture2D clrTex = GetComponent<ColorSourceManager>()._Texture;

        // this.gameObject.GetComponent<MeshRenderer>().material.SetTexture("clrTex", clrTex);
        this.gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Unlit/Texture");

    }
}
