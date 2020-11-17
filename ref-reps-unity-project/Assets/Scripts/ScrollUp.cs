using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUp : MonoBehaviour
{
    PinWheel PinWheel;
    // Start is called before the first frame update
    void Start()
    {
        PinWheel = GameObject.Find("PinWheel").GetComponent<PinWheel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonExecute(){
        PinWheel.frontObject++;
    }
}
