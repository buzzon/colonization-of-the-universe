using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public ResourceType Type;
    public float Count;

    public Resource(ResourceType type)
    {
        Type = type;
        Count = 0;
    }
}

public enum ResourceType
{
    Energy, Coal, length
}