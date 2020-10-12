using UnityEngine;
using System.Collections;
using Windows.Kinect;
using UnityEngine.UI;

public class ColorSourceViewTitle : MonoBehaviour
{
    public GameObject ColorSourceManager;
    private ColorSourceManagerTitle _ColorManager;
    
    void Start ()
    {
        gameObject.GetComponent<Image>().material.SetTextureScale("_MainTex", new Vector2(1, 1));
    }
    
    void Update()
    {
        if (ColorSourceManager == null)
        {
            return;
        }
        
        _ColorManager = ColorSourceManager.GetComponent<ColorSourceManagerTitle>();
        if (_ColorManager == null)
        {
            return;
        }
        
        GetComponent<Image>().material.mainTexture = _ColorManager.GetColorTexture();
    }
}
