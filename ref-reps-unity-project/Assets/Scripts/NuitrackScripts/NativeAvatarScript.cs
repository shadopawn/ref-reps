using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeAvatarScript : MonoBehaviour
{
    string message = "";
    public nuitrack.JointType[] typeJoint;
    GameObject[] CreatedJoint;
    public GameObject PrefabJoint;

    void Start(){

        CreatedJoint = new GameObject[typeJoint.Length];

        for(int q = 0; q < typeJoint.Length; q++){
            CreatedJoint[q] = Instantiate(PrefabJoint);
            CreatedJoint[q].transform.SetParent(transform);
            CreatedJoint[q].gameObject.name = typeJoint[q].ToString();

            if(CreatedJoint[q].name == "Head"){
                Transform callParent = GameObject.Find("CallNodesBaseball").transform;
                int children = callParent.childCount;
                for(int i = 0; i < children; i++){
                    // callParent.GetChild(0).transform.parent = newJoint.transform;
                    GameObject newNode = Instantiate(callParent.GetChild(i).gameObject);
                    newNode.transform.position = new Vector2(0,0);
                    newNode.transform.parent = CreatedJoint[q].transform;
                }
            }
        }

        message = "Skeleton created";
    }

    void Update(){
        if(CurrentUserTracker.CurrentUser != 0){
            nuitrack.Skeleton skeleton = CurrentUserTracker.CurrentSkeleton;

            message = "Skeleton found";

            for(int q = 0; q < typeJoint.Length; q++){
                nuitrack.Joint joint = skeleton.GetJoint(typeJoint[q]);
                Vector3 newPosition = 0.01f * joint.ToVector3();
                CreatedJoint[q].transform.localPosition = newPosition;
            }
        }
        else{
            message = "User not found";
        }

        // Debug.Log(message);
    }
}
