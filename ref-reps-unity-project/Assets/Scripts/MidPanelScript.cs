using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidPanelScript : MonoBehaviour
{
    Dropdown sportsDropdown;
    public Dropdown[] callDropdowns;
    Text callsHeader;
    List<string> callOptionsBaseball = new List<string> {};
    List<string> callOptionsFootball = new List<string> {};

    // Start is called before the first frame update
    void Start()
    {
        callsHeader = GameObject.Find("SelectCallsHeader").GetComponent<Text>();
        sportsDropdown = GameObject.Find("Sport-Dropdown").GetComponent<Dropdown>();
        callsHeader.text = "Select 3 Calls - " + sportsDropdown.captionText.text;
        for(int i = 0; i <= 2; i++){
            callDropdowns[i] = GameObject.Find("Call" + (i+1) + "-Dropdown").GetComponent<Dropdown>();
        }

        sportsDropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });

        
    }

    void DropdownValueChanged(){
        callsHeader.text = "Select 3 Calls - " + sportsDropdown.captionText.text;
        foreach(Dropdown callDropdown in callDropdowns){
            callDropdown.ClearOptions();        
        }


        if(sportsDropdown.captionText.text == "Baseball"){
            GameObject baseballCalls = GameObject.Find("BaseballCalls");
            int callsNum = baseballCalls.transform.childCount;
            for(int i = 0; i < callsNum; i++){
                callOptionsBaseball.Add(baseballCalls.transform.GetChild(i).name);
            }
            foreach(Dropdown callDropdown in callDropdowns){
                callDropdown.AddOptions(callOptionsBaseball);
            }
        }else if(sportsDropdown.captionText.text == "Football"){
            GameObject footballCalls = GameObject.Find("FootballCalls");
            int callsNum = footballCalls.transform.childCount;
            for(int i = 0; i < callsNum; i++){
                callOptionsFootball.Add(footballCalls.transform.GetChild(i).name);
            }
            foreach(Dropdown callDropdown in callDropdowns){
                callDropdown.AddOptions(callOptionsFootball);
            }
        }
    }
}
