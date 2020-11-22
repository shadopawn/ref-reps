using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class IconInteractScript : MonoBehaviour
{
    public string callName;
    GameObject callUIObject;
    videoPlayerScript vpScript;
    char[] charsToTrim;
    // Start is called before the first frame update
    void Start()
    {
        charsToTrim = new char[]{'I','c','o','n'};
        vpScript = GameObject.Find("CurrentVideo").GetComponent<videoPlayerScript>();
        callUIObject = this.gameObject;
        callName = this.gameObject.name.Remove(this.gameObject.name.Length - 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishCall(){
        Debug.Log(callName);
        vpScript.CheckCall(callName, callUIObject);
    }
}
