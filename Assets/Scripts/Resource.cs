using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public string Name;
    public float Count;
    public float Factor;

    public Resource(string name)
    {
        Name = name;
        Count = 0;
        Factor = 0;
    }
}

public enum ResourceType
{
    Energy, Coal, lenght
}