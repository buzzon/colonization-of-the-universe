using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    Dictionary<ResourceType, int> ResourcesUses { get; }
    Dictionary<ResourceType, int> ResourcesProduces { get; }
    void Set();
}
