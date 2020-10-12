using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virtualCursorScript : MonoBehaviour
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
            this.gameObject.transform.position = new Vector3(lh.transform.position.x * 5f, lh.transform.position.y * 5f, 0);
        }
    }
}
