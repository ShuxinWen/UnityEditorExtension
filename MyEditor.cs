using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EditorTest))]
[ExecuteInEditMode]
public class MyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorTest editorTest = (EditorTest)target;
        editorTest.rectValue = EditorGUILayout.RectField("窗口坐标设置", editorTest.rectValue);
        editorTest.texture = EditorGUILayout.ObjectField("选择贴图", editorTest.texture, typeof(Texture), true) as Texture;
    }
}
