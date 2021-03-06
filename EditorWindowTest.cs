using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWindowTest : EditorWindow
{
    [MenuItem("Tools/OpenWindow")]
    static void OpenWindow()
    {
        Rect rect = new Rect(0, 0, 500, 500);
        EditorWindowTest window = (EditorWindowTest)EditorWindow.GetWindowWithRect(typeof(EditorWindowTest), rect, true, "自定义创建窗口");
        window.Show();
    }
    //输入框输入的文字内容
    private string text;
    //选择的贴图
    private Texture texture;
    private void OnGUI()
    {
        //输入框
        text = EditorGUILayout.TextField("请输入内容：", text);
        //打开通知
        if (GUILayout.Button("打开通知", GUILayout.Width(200)))
        {
            //打开一个通知栏
            this.ShowNotification(new GUIContent("这是一条通知消息"));
        }
        //关闭通知
        if (GUILayout.Button("关闭通知", GUILayout.Width(200)))
        {
            //关闭通知栏
            this.RemoveNotification();
        }
        //添加文本框并显示鼠标位置
        EditorGUILayout.LabelField("鼠标位置：", Event.current.mousePosition.ToString());
        //选择贴图
        texture = EditorGUILayout.ObjectField("选择贴图", texture, typeof(Texture), true) as Texture;
    }
    private void OnFocus()
    {
        Debug.Log("当窗口获得焦点时调用一次");
    }
    private void OnLostFocus()
    {
        Debug.Log("当窗口失去焦点时调用一次");
    }
    private void OnHierarchyChange()
    {
        Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
    }
    private void OnProjectChange()
    {
        Debug.Log("当Project视图中的任何对象发生改变时调用一次");
    }
    private void OnInspectorUpdate()
    {
        Debug.Log("窗口面板的热更新");
        //开启窗口重绘，否则信息不会刷新
        this.Repaint();
    }
    private void OnSelectionChange()
    {
        //当窗口处于开启状态，并且在Hierarchy视图中选择某游戏对象时调用
        foreach (var item in Selection.transforms)
        {
            //有可能多选，这里开启一个循环
            Debug.Log("OnSelectionChange：" + item.name);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("当窗口关闭时调用");
    }
}
