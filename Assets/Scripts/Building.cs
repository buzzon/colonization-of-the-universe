using System;
using UnityEngine;

[Serializable]
public class Building
{
    public BuildingType Type;
    public Vector3 Position;
    public Quaternion Rotation;

    public Building(BuildingType type, Vector3 position, Quaternion rotation)
    {
        Type = type;
        Position = position;
        Rotation = rotation;
    }
}