using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Video;

public class VideoSelection : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private GameObject _videoSelectionCanvas;

    private Database _database = new Database();
    // Start is called before the first frame update
    async void Start()
    {
        _videoPlayer = GameObject.Find("CurrentVideo")?.GetComponent<VideoPlayer>();
        _videoSelectionCanvas = GameObject.Find("VideoSelectionCanvas");
        
        String json = await _database.GetLessonPacksJson();
        
        JObject lessonPacks = JObject.Parse(json);
        JToken lessonPairs = lessonPacks["lesson_pack0"]?["lesson_pairs"];
        if (lessonPairs != null)
        {
            foreach (JToken lessonPair in lessonPairs)
            {
                foreach (JToken videos in lessonPair.Children())
                {
                    Debug.Log(videos.Value<String>("call_video"));
                    Debug.Log(videos.Value<String>("analysis_video"));
                }
            }
        }
        
        String videoURL = await _database.GetVideoURL("test.mp4");
        Debug.Log(videoURL);

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
}
