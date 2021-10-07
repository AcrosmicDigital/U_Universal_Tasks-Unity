using UnityEngine;
using UnityEditor;


#if UNITY_EDITOR

public class VersionMenuButton : EditorWindow
{

    [MenuItem("U/Universal Tasks/Version")]
    public static void PrintVersion()
    {

        Debug.Log(" U Framework: Universal Tasks v1.0.0 for Unity");

    }
}


#endif
