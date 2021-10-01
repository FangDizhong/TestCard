using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class CustomEditorWindow : EditorWindow 
{

    [MenuItem("TestCard/CustomWindow")]
    private static void ShowWindow() {
        var window = GetWindow<CustomEditorWindow>();
        window.titleContent = new GUIContent("CustomWindow");
        window.Show();
    }

    private void OnGUI() 
    {
        GUILayout.Label("Cube Spawner", EditorStyles.boldLabel);
        if (GUILayout.Button("Spawn Cube"))
        {
            SpawnCube();
        }

        GUILayout.Label("Reload Item Database", EditorStyles.boldLabel);
        if (GUILayout.Button("Reload Items"))
        {
            GameObject.Find("Database").GetComponent<LoadExcel>().LoadItemData();
        }
    }

    void SpawnCube ()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0,0,0);
    }
}
