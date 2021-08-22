using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneTest))]
public class SceneEditor : Editor
{
    private void OnSceneGUI()
    {
        SceneTest test = (SceneTest)target;
        //绘制文本框
        Handles.Label(test.transform.position + Vector3.up * 2, test.transform.name + ":" + test.transform.position.ToString());
        //开始绘制GUI
        Handles.BeginGUI();
        //GUI的显示区域
        GUILayout.BeginArea(new Rect(100, 100, 200, 200));

        //绘制按钮
        if (GUILayout.Button("测试按钮"))
        {
            Debug.Log("点击了Scene视图中的测试按钮！");
        }
        //绘制文本框
        GUILayout.Label("Scene视图中的文本框!");

        //结束绘制
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}
