using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virtualCursorTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("HandLeft") != null){
            GameObject lh = GameObject.Find("HandLeft");
            this.gameObject.transform.position = new Vector3((lh.transform.position.x * 500f) + 950, lh.transform.position.y * 500f, 0);
        }
    }
}
