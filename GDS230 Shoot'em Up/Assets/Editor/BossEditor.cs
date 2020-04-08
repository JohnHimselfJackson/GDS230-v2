using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BossScript))]
public class BossEditor : Editor
{
    private void OnSceneGUI()
    {
        BossScript BS = target as BossScript;
        Handles.color = Color.green;
        Handles.DrawDottedLine(BS.bossAreaStart + Vector3.down * 5, BS.bossAreaStart + Vector3.up * 5, 10);
        Handles.color = Color.blue;
        Handles.DrawDottedLine(BS.bossAreaPlayerLimit + Vector3.down * 5, BS.bossAreaPlayerLimit + Vector3.up * 5, 10);
        Handles.color = Color.red;
        Handles.DrawDottedLine(BS.bossAreaEnd + Vector3.down * 5, BS.bossAreaEnd + Vector3.up * 5, 10);
        Handles.color =  Color.white;
        Handles.DotHandleCap(0, BS.laserScanStart, Quaternion.identity, 0.1f, EventType.Repaint);
        Handles.DotHandleCap(0, BS.laserScanEnd, Quaternion.identity, 0.1f, EventType.Repaint);
        Handles.color = Color.magenta;
        Handles.DotHandleCap(0, BS.laserStartPoint, Quaternion.identity, 0.1f, EventType.Repaint);
    }
}

