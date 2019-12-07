using System;

[Serializable]
public class Resource
{
    public ResourceType Type;
    public int Count;

    public Resource(ResourceType type)
    {
        Type = type;
        Count = 0;
    }
}

public enum ResourceType
{
    Energy, Coal, Wood, Iron, length
}