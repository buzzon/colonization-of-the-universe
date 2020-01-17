using System;

[Serializable]
public class Resource
{
    public ResourceType Type;
    public int Count;

    public Resource(ResourceType type, int count)
    {
        Type = type;
        Count = count;
    }
}