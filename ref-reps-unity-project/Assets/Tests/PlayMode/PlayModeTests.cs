using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Windows;

namespace Tests
{
    public class PlayModeTests
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SamplePlayModeTest()
        {
            yield return null;
            Assert.AreEqual(true, true);
        }
        
        
        [UnityTest]
        public IEnumerator DownloadVideoTest()
        {
            Database _database = new Database();
            _database.DownloadFile("test_files/test.mp4");
            String downloadPath = Application.dataPath + "/VideoFiles/test.mp4";
            bool fileExists = false;
            float time = 0;
            float timeIncrement = 0.05f;
            float timeOut = 500;
            while (time < timeOut && fileExists == false)
            {
                fileExists = File.Exists(downloadPath);
                yield return new WaitForSeconds(timeIncrement);
                time += timeIncrement;
            }
            Assert.True(fileExists);
            Debug.Log("Time to download test file " + time);
            yield return new WaitForSeconds(0.6f);
            File.Delete(downloadPath);
        }
    }
}
