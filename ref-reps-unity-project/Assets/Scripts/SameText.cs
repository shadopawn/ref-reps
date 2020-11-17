using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class SameText : MonoBehaviour
{
    public Text[] TextFill;

    Text parentText;

    // Start is called before the first frame update
    void Start()
    {
        parentText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Text thisText in TextFill){
            thisText.text = parentText.text;
        }
    }
}
