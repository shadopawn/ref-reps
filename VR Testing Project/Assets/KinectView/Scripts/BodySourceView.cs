using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour 
{
    public BodySourceManager mBodySourceManager;
    // public GameObject BodyParent;
    public GameObject mJointObject;
    public GameObject threePointNode;
    public GameObject blockingNode;
    public GameObject personalFoulNode;
    public GameObject outNode;
    public GameObject safeNode;
    public GameObject timeOutNode;
    public GameObject doNotPitchNode;
    public GameObject playBallNode;
    public GameObject BodyErrorMessage;

    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private BodySourceManager _BodyManager;

    private List<JointType> _joints = new List<JointType>
    {
        JointType.HandLeft,
        JointType.HandRight,
        JointType.ElbowLeft,
        JointType.ElbowRight,
        JointType.Head,
        JointType.HipLeft,
        JointType.HipRight,
        JointType.ShoulderRight,
        JointType.ShoulderLeft,
        JointType.KneeLeft,
        JointType.AnkleLeft,
        JointType.KneeRight,
        JointType.AnkleRight,
    };

    
    // private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    // {
    //     { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
    //     { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
    //     { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
    //     { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
        
    //     { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
    //     { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
    //     { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
    //     { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
        
    //     { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
    //     { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
    //     { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
    //     { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
    //     { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
    //     { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
        
    //     { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
    //     { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
    //     { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
    //     { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
    //     { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
    //     { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
        
    //     { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
    //     { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
    //     { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
    //     { Kinect.JointType.Neck, Kinect.JointType.Head },
    // };
    
    void Update () 
    {
        #region Get Kinect data
        Body[] data = mBodySourceManager.GetData();
        if(data == null)
            return;

        List<ulong> trackedIds = new List<ulong>();
        foreach (var body in data)
        {
            if(body == null)
                continue;

            if(body.IsTracked)
                trackedIds.Add(body.TrackingId);
        }
        #endregion

        #region Delete Kinect bodies
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        foreach (ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                // Destroy body object
                Destroy(mBodies[trackingId]);
                BodyErrorMessage.SetActive(true);

                // Remove from list
                mBodies.Remove(trackingId);
            }
        }
        #endregion

        #region Create Kinect bodies
        foreach (var body in data)
        {
            //If no body, skip
            if(body == null)
                continue;

            if(body.IsTracked)
            {
                BodyErrorMessage.SetActive(false);
                // If body isn't tracked, create body
                if(!mBodies.ContainsKey(body.TrackingId))
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);

                //Update positions
                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }
        #endregion
    }
    
    private GameObject CreateBodyObject(ulong id)
    {
        // Create body parent
        GameObject body = new GameObject("Body:" + id);
        
        // Create joints
        foreach (JointType joint in _joints)
        {
            // Create Object
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();

            //Attach CallNodes to Head Joint
            if(newJoint.name == "Head"){
                Transform callParent = GameObject.Find("CallNodesBaseball").transform;
                int children = callParent.childCount;
                for(int i = 0; i < children; i++){
                    // callParent.GetChild(0).transform.parent = newJoint.transform;
                    GameObject newNode = Instantiate(callParent.GetChild(i).gameObject);
                    newNode.transform.position = new Vector2(0,0);
                    newNode.transform.parent = newJoint.transform;
                }

                callParent = GameObject.Find("CallNodesFootball").transform;
                children = callParent.childCount;
                for(int i = 0; i < children; i++){
                    GameObject newNode = Instantiate(callParent.GetChild(i).gameObject);
                    newNode.transform.position = new Vector2(0,0);
                    newNode.transform.parent = newJoint.transform;
                }

                callParent = GameObject.Find("CallNodesBasketball").transform;
                children = callParent.childCount;
                for(int i = 0; i < children; i++){
                    GameObject newNode = Instantiate(callParent.GetChild(i).gameObject);
                    newNode.transform.position = new Vector2(0,0);
                    newNode.transform.parent = newJoint.transform;
                }
            }

            // Parent to body
            newJoint.transform.parent = body.transform;
        }
        
        return body;
    }
    
    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        // Update joints
        foreach (JointType _joint in _joints)
        {
            //Get new target position
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            // Get joint, set new position
            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
