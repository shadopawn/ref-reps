using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFrameScript : MonoBehaviour
{
    [SerializeField] RawImage BackGround;

    // Start is called before the first frame update
    void Start()
    {
        NuitrackManager.onColorUpdate += DrawColor;
    }

    void DrawColor(nuitrack.ColorFrame frame){
        BackGround.texture = frame.ToTexture2D();
    }
}
