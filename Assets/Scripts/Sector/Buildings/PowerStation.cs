using System.Collections.Generic;
using UnityEngine;

public class PowerStation : MonoBehaviour, IBuilding
{
    public Dictionary<ResourceType, int> ResourcesUses { get; private set; }
    public Dictionary<ResourceType, int> ResourcesProduces { get; private set; }

    public void Set()
    {
        ResourcesUses = new Dictionary<ResourceType, int>()
        {
            { ResourceType.Coal, 2 }
        };
        ResourcesProduces = new Dictionary<ResourceType, int>()
        {
            { ResourceType.Energy, 2 }
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
