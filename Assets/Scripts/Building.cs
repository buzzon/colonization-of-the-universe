using System;
using UnityEngine;

[Serializable]
public class Building
{
    public BuildingType Type;
    public Vector3 Position;
    public Quaternion Rotation;
    public bool IsWork;

    public Building(BuildingType type, Vector3 position, Quaternion rotation, bool isWork)
    {
        Type = type;
        Position = position;
        Rotation = rotation;
        IsWork = isWork;
    }
}