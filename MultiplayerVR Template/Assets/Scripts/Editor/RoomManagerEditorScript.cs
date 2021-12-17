using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var roomManager = (RoomManager) target;
        EditorGUILayout.HelpBox("This script is responsible for creating rooms", MessageType.Info);
        if (GUILayout.Button("Join random room"))
        {
            roomManager.JoinRandomRoom();
        }
    }
}
