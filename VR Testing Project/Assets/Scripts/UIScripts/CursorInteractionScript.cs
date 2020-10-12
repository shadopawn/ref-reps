using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorInteractionScript : MonoBehaviour
{
    bool isClick;

    public enum Hands { left = 0, right = 1};

    [SerializeField]
    Hands currentHand;

    public bool press;

    void Start()
    {
        NuitrackManager.onHandsTrackerUpdate += NuitrackManager_onHandsTrackerUpdate;
    }                       

    private void OnDestroy(){
        NuitrackManager.onHandsTrackerUpdate -= NuitrackManager_onHandsTrackerUpdate;
    }

    private void NuitrackManager_onHandsTrackerUpdate(nuitrack.HandTrackerData _handTrackerData ){

        foreach (nuitrack.UserHands userHands in _handTrackerData.UsersHands){
            if (currentHand == Hands.right && userHands.RightHand != null){
                press = userHands.RightHand.Value.Click;
            }
            else if(currentHand == Hands.left && userHands.LeftHand != null){
                press = userHands.LeftHand.Value.Click;
            }
        }
    }

}
