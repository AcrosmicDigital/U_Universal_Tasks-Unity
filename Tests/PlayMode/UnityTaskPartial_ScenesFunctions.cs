//using System.Collections;
//using System.Collections.Generic;
//using NUnit.Framework;
//using UnityEngine;
//using UnityEngine.TestTools;
//using UnityEngine.SceneManagement;
//using U.Universal.Tasks;

//public class UnityTaskPartial_ScenesFunctions
//{
    
//    [UnityTest]
//    public IEnumerator UnityTaskPartial_LoadAndUnloadScenes()
//    {
//        GameObject host = new GameObject("Host");
//        Object.DontDestroyOnLoad(host);

//        yield return null;

//        Load();
//        async void Load()
//        {

//            await UnityTask.LoadSceneAsync(host, 0, LoadSceneMode.Single);

//            Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);

//            await UnityTask.LoadSceneAsync(host, 1, LoadSceneMode.Additive);
//            await UnityTask.UnloadSceneAsync(host, 0);

//            Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);

//            await UnityTask.LoadSceneAsync(host, "Menu", LoadSceneMode.Single);

//            Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

//            await UnityTask.LoadSceneAsync(host, "Level1", LoadSceneMode.Additive);
//            await UnityTask.UnloadSceneAsync(host, "Menu");

//            Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);

//        }

//        yield return new WaitForSecondsRealtime(5);

//    }


//    [UnityTest]
//    public IEnumerator UnityTaskPartial_WhileLoadAndUnloadDelegates()
//    {
//        GameObject host = new GameObject("Host");
//        Object.DontDestroyOnLoad(host);

//        yield return null;


//        void WhileLoad(float p)
//        {
//            Debug.Log("Loading: " + p);
//        }

//        void WhileUnload()
//        {
//            Debug.Log("Unloading");
//        }



//        Load();
//        async void Load()
//        {

//            await UnityTask.LoadSceneAsync(host, 0, LoadSceneMode.Single, WhileLoad);

//            Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);

//            await UnityTask.LoadSceneAsync(host, 1, LoadSceneMode.Additive, WhileLoad);
//            await UnityTask.UnloadSceneAsync(host, 0, WhileUnload);

//            Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);

//            await UnityTask.LoadSceneAsync(host, "Menu", LoadSceneMode.Single, WhileLoad);

//            Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

//            await UnityTask.LoadSceneAsync(host, "Level1", LoadSceneMode.Additive, WhileLoad);
//            await UnityTask.UnloadSceneAsync(host, "Menu", WhileUnload);

//            Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);

//        }

//        yield return new WaitForSecondsRealtime(5);

//    }


//    [UnityTest]
//    public IEnumerator UnityTaskPartial_WhileLoadAndUnloadDelegates_ButError()
//    {
//        GameObject host = new GameObject("Host");
//        Object.DontDestroyOnLoad(host);

//        yield return null;


//        void WhileLoad(float p)
//        {
//            throw new System.Exception("Loading: " + p);
//        }

//        void WhileUnload()
//        {
//            throw new System.Exception("Unloading");
//        }


//        LogAssert.ignoreFailingMessages = true;
//        Load();
//        async void Load()
//        {

//            await UnityTask.LoadSceneAsync(host, 0, LoadSceneMode.Single, WhileLoad);

//            Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);

//            await UnityTask.LoadSceneAsync(host, 1, LoadSceneMode.Additive, WhileLoad);
//            await UnityTask.UnloadSceneAsync(host, 0, WhileUnload);

//            Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);

//            await UnityTask.LoadSceneAsync(host, "Menu", LoadSceneMode.Single, WhileLoad);

//            Assert.AreEqual("Menu", SceneManager.GetActiveScene().name);

//            await UnityTask.LoadSceneAsync(host, "Level1", LoadSceneMode.Additive, WhileLoad);
//            await UnityTask.UnloadSceneAsync(host, "Menu", WhileUnload);

//            Assert.AreEqual("Level1", SceneManager.GetActiveScene().name);


//        }

//        yield return new WaitForSecondsRealtime(5);

//    }
//}
