using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    Dictionary<ResourceType, float> ResourcesUses { get; }
    Dictionary<ResourceType, float> ResourcesProduces { get; }
    void Set();
}
