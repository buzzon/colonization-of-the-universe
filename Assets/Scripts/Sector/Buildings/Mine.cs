using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IBuilding
{
    public Dictionary<ResourceType, int> ResourcesUses { get; private set; }
    public Dictionary<ResourceType, int> ResourcesProduces { get; private set; }

    public void Set()
    {
        ResourcesUses = new Dictionary<ResourceType, int>()
        {
            { ResourceType.Energy, 2 }
        };
        ResourcesProduces = new Dictionary<ResourceType, int>()
        {
            { ResourceType.Coal, 3 }
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
