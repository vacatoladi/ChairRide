using System;
using UnityEngine;


[Serializable]
public struct MissionData
{
    public int Id;
    public int Value;
    [TextArea(1,3)] public string Mission;
}

[CreateAssetMenu(fileName = "MissionData", menuName = "Scriptable Objects/MissionData")]
public class MissionDataScript : ScriptableObject
{
    public MissionData[] Missions;
}
