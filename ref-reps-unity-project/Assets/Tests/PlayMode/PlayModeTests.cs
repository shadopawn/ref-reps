using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
            
            yield return new WaitForSeconds(5);
            Assert.AreEqual(true, true);
        }
        
    }
}
