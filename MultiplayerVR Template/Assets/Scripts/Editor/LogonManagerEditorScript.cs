using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LoginManager))]
public class LogonManagerEditorScript : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var loginManager = (LoginManager) target;
        EditorGUILayout.HelpBox("This script is responsible to connect to photon server", MessageType.Info);
        if (GUILayout.Button("Connect Anonymously"))
        {
            loginManager.ConnectAnonymously();
        }
    }
}
