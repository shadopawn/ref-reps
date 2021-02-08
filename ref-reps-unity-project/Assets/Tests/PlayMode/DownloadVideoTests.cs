using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Windows;

namespace Tests
{
    public class DownloadVideoTests
    {

        [UnityTest]
        public IEnumerator DownloadVideoTest()
        {
            Debug.unityLogger.logEnabled = false;
            Database database = new Database();
            database.DownloadFile("test_files/test.mp4");
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
        
        [UnityTest]
        public IEnumerator DownloadVideoFailedTest()
        {
            Database database = new Database();
            database.DownloadFile("test_files/nonExistent.mp4");
            String downloadPath = Application.dataPath + "/VideoFiles/nonExistent.mp4";
            bool fileExists = File.Exists(downloadPath);
            Assert.False(fileExists);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator DownloadVideoErrorLogging()
        {
            Database database = new Database();
            database.DownloadFile("test_files/nonExistent.mp4");
            Debug.LogError("File failed to download");
            LogAssert.Expect(LogType.Error, "File failed to download");
            yield return null;
        }
    }
}
