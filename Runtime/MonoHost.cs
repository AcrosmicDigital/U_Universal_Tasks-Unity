using UnityEngine;



/// <summary>
/// This classes allows you to acces to a GameObject and and components inside
/// This GO is in the active scene, so if this scene is downloaded all the components will be destryed
/// There are only one monohost active in the active scene and one active in the Dont Destroy On Load scene
/// The monohost also have a Monocomponent to run StartCoroutine and that things
/// </summary>
/// <example>
/// 
/// using Sacrum.Functions.MonoHost;
/// 
/// MonoHostInDontDestroyOnLoad.Instance.MonoHost.AddComponent()
/// MonoHostInActiveScene.Instance.MonoHost.AddComponent()
/// 
/// </example>
/// 

namespace U.Universal.Tasks
{

    public sealed class MonoHost
    {
        // <Singleton Pattern>
        private readonly static MonoHost _instance = new MonoHost();
        private MonoHost() { }
        public static MonoHost Instance { get => _instance; }
        // </Singleton Pattern>



        // MonoHostInDontDestroyOnLoad
        private GameObject inDontDestroyonLoad = null;
        public GameObject InDontDestroyonLoad
        {
            get
            {

                if (inDontDestroyonLoad == null)
                {
                    inDontDestroyonLoad = new GameObject("MonoHost" + S.Uidentity.NewIdShort());
                    Object.DontDestroyOnLoad(inDontDestroyonLoad);
                }

                return inDontDestroyonLoad;

            }
        }


        // MonoHostInActiveScene
        private GameObject inActiveScene = null;
        public GameObject InActiveScene
        {
            get
            {

                if (inActiveScene == null)
                {
                    inActiveScene = new GameObject("MonoHost" + S.Uidentity.NewIdShort());
                }

                return inActiveScene;

            }
        }



        public static GameObject NewHostInActiveScene(string name)
        {
            return new GameObject(name);
        }

        public static GameObject NewHostInDontDestroyOnLoad(string name)
        {
            var go = new GameObject(name);
            UnityEngine.Object.DontDestroyOnLoad(go);
            return go;
        }

    }

}

