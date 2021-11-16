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

    internal sealed class TaskRunner
    {
        // <Singleton Pattern>
        private readonly static TaskRunner _instance = new TaskRunner();
        private TaskRunner() { }
        internal static TaskRunner Instance { get => _instance; }
        // </Singleton Pattern>



        // MonoHostInDontDestroyOnLoad
        private GameObject inDontDestroyonLoad = null;
        internal GameObject InDontDestroyonLoad
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
        internal GameObject InActiveScene
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

    }

}

