using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    public override void Set()
    {
        RequiredResources = new Resource[]
        {
            new Resource(ResourceType.Energy, 2)
        };
        ProducedResources = new Resource[]
        {
            new Resource(ResourceType.Coal, 3)
        };
        CurrentSector.Manager.AddBuilding(this);
    }
}
