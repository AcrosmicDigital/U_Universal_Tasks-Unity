using UnityEngine;
using UnityEditor;

namespace U.Universal.Tasks.Editor
{
    public class VersionMenuButton : EditorWindow
    {

        [MenuItem("Universal/Tasks/Version")]
        public static void PrintVersion()
        {

            Debug.Log(" U Framework: Universal Tasks v1.0.0 for Unity");

        }
    }
}