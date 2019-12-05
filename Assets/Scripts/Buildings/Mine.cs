using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IBuilding
{
    public Dictionary<ResourceType, float> ResourcesUses { get; private set; }
    public Dictionary<ResourceType, float> ResourcesProduces { get; private set; }

    public void Set()
    {
        ResourcesUses = new Dictionary<ResourceType, float>()
        {
            { ResourceType.Energy, 1 }
        };
        ResourcesProduces = new Dictionary<ResourceType, float>()
        {
            { ResourceType.Coal, 2 }
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
