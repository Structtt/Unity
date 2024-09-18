using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WayPoint))]
public class WayPointEditor : Editor
{
    WayPoint wayPoint => target as WayPoint;
    private void OnSceneGUI()
    {

        Handles.color = Color.red;
        for (int i = 0; i < wayPoint.Points.Length; i++)
        {

            //检查起始点
            EditorGUI.BeginChangeCheck();

            //绘制红点
            Vector3 currentWayPoint = wayPoint.CurrentPosition + wayPoint.Points[i];
            var fmh_23_17_638613171449308372 = Quaternion.identity; Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWayPoint, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);


            //数字标记
            GUIStyle text = new GUIStyle();
            text.fontStyle = FontStyle.Bold;
            text.fontSize = 16;
            text.normal.textColor = Color.yellow;
            Vector3 textAlligment = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(wayPoint.CurrentPosition + wayPoint.Points[i] + textAlligment, $"{i + 1}",text);

            EditorGUI.EndChangeCheck();
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "新的点位");
                wayPoint.Points[i] = newWaypointPoint - wayPoint.CurrentPosition;
            }
        }        
    }
}
