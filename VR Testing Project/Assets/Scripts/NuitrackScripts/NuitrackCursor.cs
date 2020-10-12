using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NuitrackCursor : MonoBehaviour
{
    GameObject leftHand;

    public enum Hands { left = 0, right = 1};

    [SerializeField]
    Hands currentHand;

    // [SerializeField]
    // RectTransform baseRect;

    [SerializeField]
    SpriteRenderer background;

    [SerializeField]
    Sprite defaultSprite;

    [SerializeField]
    Sprite pressSprite;

    // Start is called before the first frame update
    void Start()
    {
        NuitrackManager.onHandsTrackerUpdate += NuitrackManager_onHandsTrackerUpdate;
    }                       

    private void OnDestroy(){
        NuitrackManager.onHandsTrackerUpdate -= NuitrackManager_onHandsTrackerUpdate;
    }

    void Update(){
        leftHand = GameObject.Find("LeftHand");
        if(leftHand != null){
            transform.position = new Vector3(-leftHand.transform.position.x * 3, leftHand.transform.position.y * 3, 0);
        }
    }

    private void NuitrackManager_onHandsTrackerUpdate(nuitrack.HandTrackerData _handTrackerData ){
        bool active = false;
        bool press = false;

        foreach (nuitrack.UserHands userHands in _handTrackerData.UsersHands){
            if (currentHand == Hands.right && userHands.RightHand != null){
                // baseRect.anchoredPosition = new Vector2(userHands.RightHand.Value.X * Screen.width, -userHands.RightHand.Value.Y * Screen.height);
                active = true;
                press = userHands.RightHand.Value.Click;
            }
            else if(currentHand == Hands.left && userHands.LeftHand != null){
                // baseRect.anchoredPosition = new Vector2(userHands.LeftHand.Value.X * Screen.width, -userHands.LeftHand.Value.Y * Screen.height);
                active = true;
                press = userHands.LeftHand.Value.Click;
            }
        }

        background.enabled = active;
        background.sprite = active && press ? pressSprite : defaultSprite;
    }
}
