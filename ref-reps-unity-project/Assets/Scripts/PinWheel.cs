using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinWheel : MonoBehaviour
{
    public List<GameObject> wheelObjects;

    public int frontObject;
    // Start is called before the first frame update
    void Start()
    {
        FindChildren();
    }

    public void FindChildren(){
        for(int i = 0; i < transform.childCount; i++){
            wheelObjects.Add(transform.GetChild(i).gameObject);
        }
    }

    public void DestroyChildren(){
        for(int i = 0; i < wheelObjects.Count; i++){
            wheelObjects.RemoveAt(0);
        }
        for(int i = 0; i < transform.childCount; i++){
            Destroy(transform.GetChild(i).gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        for(int i = 0; i < transform.childCount; i++){
            int wheelIndex;
            if(i == frontObject - 1 || (i == transform.childCount - 1 && frontObject - 1 < 0)){
                wheelIndex = 0;
            }
            else if(i == frontObject + 1 || (i == 0 && frontObject + 1 >= transform.childCount)){
                wheelIndex = 2;
            }else if(i == frontObject){
                wheelIndex = 1;
            }else{
                wheelIndex = 3;
            }
            transform.GetChild(i).gameObject.GetComponent<Animator>().SetInteger("wheelIndex", wheelIndex);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0){
            frontObject--;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            frontObject++;
        }

        if(Input.GetKeyDown("w")){
            frontObject++;
        }
        if(Input.GetKeyDown("s")){
            frontObject--;
        }

        if(frontObject >= wheelObjects.Count){
            frontObject = 0;
        }

        if(frontObject < 0){
            frontObject = wheelObjects.Count-1;
        }
    }
}
