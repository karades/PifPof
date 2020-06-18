using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(WeaponStats))]
public class WeaponStatsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WeaponStats weaponStats = (WeaponStats)target;

        if(GUILayout.Button("Refresh all Ammo"))
        {
            weaponStats.refreshAmmo();
        }
        //EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
    }
}