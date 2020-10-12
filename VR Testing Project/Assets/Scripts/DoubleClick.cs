using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick : MonoBehaviour
{
    public float doubleClickTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DoubleClickTimer
        if(doubleClickTimer > 0){
            doubleClickTimer--;
        }
    }


    public void doDoubleClick(){
        if(doubleClickTimer > 10){
            this.gameObject.SendMessage("titleExecute", SendMessageOptions.DontRequireReceiver);
        }
        doubleClickTimer = 200;
    }
}
