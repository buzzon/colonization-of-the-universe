using System.Collections.Generic;
using UnityEngine;

public class PowerStation : Building
{
    public override void Set()
    {
        RequiredResources = new Resource[]
        {
            new Resource(ResourceType.Coal, 2)
        };
        ProducedResources = new Resource[]
        {
            new Resource(ResourceType.Energy, 2)
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
