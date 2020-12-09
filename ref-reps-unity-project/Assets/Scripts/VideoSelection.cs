using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSelection : MonoBehaviour
{
    public GameObject buttonPrefab;
    
    private VideoPlayer _videoPlayer;
    private GameObject _videoSelectionCanvas;
    private GameObject _buttonList;

    private Database _database = new Database();
    // Start is called before the first frame update
    async void Start()
    {
        _videoPlayer = GameObject.Find("CurrentVideo")?.GetComponent<VideoPlayer>();
        _videoSelectionCanvas = GameObject.Find("VideoSelectionCanvas");
        _buttonList = GameObject.Find("VideoSelectionCanvas/ButtonList");
        
        String json = await _database.GetLessonPacksJson();
        
        JObject lessonPacks = JObject.Parse(json);
        JToken lessonPairs = lessonPacks["lesson_pack0"]?["lesson_pairs"];
        if (lessonPairs != null)
        {
            foreach (JToken lessonPair in lessonPairs)
            {
                foreach (JToken videos in lessonPair.Children())
                {
                    String callVideoFileName = videos.Value<String>("call_video");
                    String analysisVideoFileName = videos.Value<String>("analysis_video");
                    String callVideoURL = await _database.GetVideoURL(callVideoFileName);
                    String analysisVideoURL = await _database.GetVideoURL(analysisVideoFileName);
                    CreateNewButton(callVideoURL, callVideoFileName);
                    CreateNewButton(analysisVideoURL, analysisVideoFileName);

                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo(String videoUrl)
    {
        _videoPlayer.url = videoUrl;
        _videoPlayer.Play();
        _videoSelectionCanvas.SetActive(false);
    }

    private void CreateNewButton(String videoUrl, String buttonText = "Button Text")
    {
        GameObject newButton = Instantiate(buttonPrefab, _buttonList.transform);
        Button buttonComponent = newButton.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => PlayVideo(videoUrl));
        Text buttonTextComponent = newButton.GetComponentInChildren<Text>();
        buttonTextComponent.text = buttonText;
    }
}
